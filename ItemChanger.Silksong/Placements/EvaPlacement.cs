using ItemChanger.Placements;
using ItemChanger.Locations;
using ItemChanger.Tags;
using ItemChanger.Silksong.Locations;

namespace ItemChanger.Silksong.Placements;

public class EvaPlacement(string Name) : Placement(Name), IMultiCostPlacement, IPrimaryLocationPlacement
{
    /// <summary>
    /// Location responsible for delivering placed items.
    /// </summary>
    public required EvaLocation Location { get; init; }

    /// <summary>
    /// The set of items that should be handled by the vanilla Eva dialogue.
    /// Those items will have their vanilla tool slot costs, which unlike ToolSlotCost
    /// do not count slots unlocked on the Hunter Crest.
    /// </summary>
    public DefaultEvaItems DefaultItems { get; set; } = 0;

    Location IPrimaryLocationPlacement.Location => Location;

    public bool AllObtainedIncludingDefault()
    {
        if ((DefaultItems & DefaultEvaItems.HunterCrestUpgrade1) != 0
            && !ToolItemManager.GetCrestByName("Hunter_v2").IsUnlocked)
        {
            return false;
        }
        if ((DefaultItems & DefaultEvaItems.VesticrestYellow) != 0
            && !PlayerData.instance.GetBool(nameof(PlayerData.UnlockedExtraYellowSlot)))
        {
            return false;
        }
        if ((DefaultItems & DefaultEvaItems.VesticrestBlue) != 0
            && !PlayerData.instance.GetBool(nameof(PlayerData.UnlockedExtraBlueSlot)))
        {
            return false;
        }
        if ((DefaultItems & DefaultEvaItems.HunterCrestUpgrade2) != 0
            && !ToolItemManager.GetCrestByName("Hunter_v3").IsUnlocked)
        {
            return false;
        }
        if ((DefaultItems & DefaultEvaItems.Sylphsong) != 0
            && !PlayerData.instance.GetBool(nameof(PlayerData.HasBoundCrestUpgrader)))
        {
            return false;
        }
        return AllObtained();
    }

    /// <inheritdoc/>
    protected override void DoLoad()
    {
        Location.Placement = this;
        Location.LoadOnce();
    }

    /// <inheritdoc/>
    protected override void DoUnload()
    {
        Location.UnloadOnce();
        Location.Placement = null;
    }

    /// <inheritdoc/>
    public override IEnumerable<Tag> GetPlacementAndLocationTags()
    {
        return base.GetPlacementAndLocationTags().Concat(Location.Tags ?? Enumerable.Empty<Tag>());
    }
}

/// <summary>
/// Specifies items that should not be removed from Eva by the EvaLocation.
/// </summary>
[Flags]
public enum DefaultEvaItems
{
    HunterCrestUpgrade1 = 1 << 1,
    VesticrestYellow = 1 << 2,
    VesticrestBlue = 1 << 3,
    HunterCrestUpgrade2 = 1 << 4,
    Sylphsong = 1 << 5
}
