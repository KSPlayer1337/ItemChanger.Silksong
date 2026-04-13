using HarmonyLib;
using ItemChanger.Costs;
using ItemChanger.Modules;
using ItemChanger.Silksong.Costs;
using MonoDetour.DetourTypes;

namespace ItemChanger.Silksong.Modules.YNBox;

/// <summary>
/// Module that allows for InteractEvents components to send more customizable YN boxes,
/// provided that the gameObject has a <see cref="CustomYNBoxInfo"/> component.
/// </summary>
public class CustomYNEnableModule : Module
{
    protected override void DoLoad()
    {
        // When an interact events is interacted with and there's a CustomYNBoxInfo component,
        // we need to modify the call to DialogueYesNoBox.Open
        Using(Md.InteractEvents.ShowYesNo.ControlFlowPrefix(OverrideInteractEventsShow));
        // Allow showing cost text, rather than sprite + image
        Using(Md.SavedItemDisplay.Setup.ControlFlowPrefix(OverrideSavedItemDisplay));
    }

    protected override void DoUnload() { }

    private ReturnFlow OverrideSavedItemDisplay(SavedItemDisplay self, ref SavedItem item, ref int amount)
    {
        if (item is not ItemChangerCostProxy costProxy
            || costProxy.Cost is IDisplayCost)
        {
            // DisplayCosts display themselves in the normal way
            // Restore the default text alignment
            self.amountText.alignment = TMProOld.TextAlignmentOptions.BottomRight;
            return ReturnFlow.None;
        }

        self.icon.sprite = null;
        self.amountText.text = costProxy.Cost.GetCostText();
        self.amountText.alignment = TMProOld.TextAlignmentOptions.Bottom;

        return ReturnFlow.SkipOriginal;
    }
    
    private ReturnFlow OverrideInteractEventsShow(InteractEvents self)
    {
        CustomYNBoxInfo info = self.gameObject.GetComponent<CustomYNBoxInfo>();
        if (info == null)
        {
            return ReturnFlow.None;
        }

        // Event backing field needs reflection to access
        Action? origInteracted = AccessTools.Field(typeof(InteractEvents), nameof(InteractEvents.Interacted)).GetValue(self) as Action;

        Open(origInteracted, self.EndInteraction, info.Cost, info.TextGetter());
        return ReturnFlow.SkipOriginal;
    }

    /// <summary>
    /// Open a YN dialogue box that displays the provided text and cost.
    /// </summary>
    /// <param name="yes">Callback invoked when "yes" is selected.</param>
    /// <param name="no">Callback invoked when "no" is selected.</param>
    /// <param name="cost">The <see cref="Cost"/> to be paid.</param>
    /// <param name="text">The text to diplay. This should describe what will happen when "yes" is selected.</param>
    /// <param name="shouldPay">If true, the cost will be paid when "yes" is selected. This should be false if cost payment
    /// is already included in the <paramref name="yes"/> delegate.</param>
    public static void Open(Action? yes, Action? no, Cost cost, string text, bool shouldPay = true)
    {
        if (shouldPay)
        {
            yes = cost.Pay + yes;
        }
        
        if (cost is ICurrencyCost currencyCost)
        {
            DialogueYesNoBox.Open(yes, no, true, text, currencyCost.CurrencyType, currencyCost.Amount, consumeCurrency: false);
            return;
        }

        List<Cost> costs = (new MultiCost(cost)).ToList();
        if (!costs.All(x => x is IDisplayCost))
        {
            ItemChangerCostProxy costOwner = ItemChangerCostProxy.FromCost(cost);
            DialogueYesNoBox.Open(yes, no, true, text, [costOwner], [1], displayHudPopup: true, consumeCurrency: false, null);
            return;
        }

        List<IDisplayCost> displayableCosts = costs.Cast<IDisplayCost>().ToList();

        List<ItemChangerCostProxy> displays = costs.Select(x => ItemChangerCostProxy.FromCost(x)).ToList();
        List<int> amounts = displayableCosts.Select(x => x.Amount).ToList();
        DialogueYesNoBox.Open(yes, no, true, text, displays, amounts, true, false, null);
    }
}
