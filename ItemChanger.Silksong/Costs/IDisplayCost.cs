using UnityEngine;

namespace ItemChanger.Silksong.Costs;

/// <summary>
/// Interface representing a cost that can (sometimes) be displayed with a sprite and an amount.
/// </summary>
public interface IDisplayCost
{
    bool DisplayEnabled { get; }

    Sprite DisplaySprite { get; }

    int Amount { get; }
}
