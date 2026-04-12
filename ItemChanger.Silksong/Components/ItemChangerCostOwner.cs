using ItemChanger.Costs;
using UnityEngine;

namespace ItemChanger.Silksong.Components;

public class ItemChangerCostOwner : SavedItem
{
    public Cost Cost;

    public static ItemChangerCostOwner FromCost(Cost cost)
    {
        ItemChangerCostOwner owner = ScriptableObject.CreateInstance<ItemChangerCostOwner>();
        owner.Cost = cost;
        return owner;
    }

    public override bool CanGetMore()
    {
        return Cost.CanPay();
    }

    public override void Get(bool showPopup = true)
    {
        Cost.Pay();
    }
}
