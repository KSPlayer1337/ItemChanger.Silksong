using ItemChanger.Costs;
using ItemChanger.Silksong.Util;

namespace ItemChanger.Silksong.Costs;

/// <summary>
/// A cost that requires having at least a given amount of tool slots unlocked.
/// Unlike the vanilla Eva costs, this includes slots unlocked on the Hunter Crest
/// or its upgrades.
/// </summary>
public class ToolSlotCost : Cost
{
    /// <summary>
    /// The amount of slots required to fulfil the cost.
    /// </summary>
    public required int Amount { get; set; }

    private static int UnlockedToolSlots()
    {
        int n = 0;
        foreach (ToolCrest crest in ToolItemManager.Instance.crestList)
        {
            if (crest.IsUnlocked && !crest.IsHidden && !crest.IsUpgradedVersionUnlocked)
            {
                foreach (ToolCrest.SlotInfo slot in crest.Slots)
                {
                    // CountCrestUnlockPoints also checks crest.SaveData.Slots;
                    // not sure why.
                    if (!slot.IsLocked)
                    {
                        n++;
                    }
                }
            }
        }
        return n;
    }

    /// <inheritdoc/>
    public override bool CanPay() => UnlockedToolSlots() >= Amount;

    /// <inheritdoc/>
    public override void OnPay() {}

    /// <inheritdoc/>
    public override bool IsFree => Amount == 0;

    /// <inheritdoc/>
    public override string GetCostText() => string.Format("FMT_PAY_TOOL_SLOTS".GetLanguageString(), Amount);

    /// <inheritdoc/>
    public override bool HasPayEffects() => false;
}
