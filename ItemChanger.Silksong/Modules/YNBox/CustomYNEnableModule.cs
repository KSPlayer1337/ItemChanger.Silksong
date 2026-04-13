using HarmonyLib;
using ItemChanger.Costs;
using ItemChanger.Modules;
using ItemChanger.Silksong.Costs;
using ItemChanger.Silksong.Extensions;
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
        // Repair any damage from before (not sure if this is necessary...)
        self.amountText.alignment = TMProOld.TextAlignmentOptions.BottomRight;

        if (item is not ItemChangerCostProxy costProxy)
        {
            // Not an ItemChanger Cost, so fall through to the original method
            return ReturnFlow.None;
        }

        if (costProxy.Cost is IDisplayCost)
        {
            // DisplayCosts are handled via the overridden methods on ItemChangerCostProxy
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
            yes = cost.PayIfNotPaid + yes;
        }
        
        if (cost is ICurrencyCost currencyCost)
        {
            int amount = cost.Paid ? 0 : currencyCost.Amount;
            DialogueYesNoBox.Open(yes, no, true, text, currencyCost.CurrencyType, amount, consumeCurrency: false);
            return;
        }

        List<Cost> costs = (new MultiCost(cost)).ToList();
        if (!costs.All(x => x is IDisplayCost))
        {
            ItemChangerCostProxy costProxy = ItemChangerCostProxy.FromCost(cost);
            if (cost.Paid)
            {
                DialogueYesNoBox.Open(yes, no, true, text, [], [], displayHudPopup: true, consumeCurrency: false, null);
            }
            else
            {
                DialogueYesNoBox.Open(yes, no, true, text, [costProxy], [1], displayHudPopup: true, consumeCurrency: false, null);
            }
            return;
        }

        List<Cost> unpaidCosts = costs.Where(x => !x.Paid).ToList();
        List<IDisplayCost> displayableCosts = unpaidCosts.Cast<IDisplayCost>().ToList();

        List<ItemChangerCostProxy> displays = unpaidCosts.Select(x => ItemChangerCostProxy.FromCost(x)).ToList();
        List<int> amounts = displayableCosts.Select(x => x.Amount).ToList();

        DialogueYesNoBox.Open(yes, no, true, text, displays, amounts, true, false, null);
    }
}
