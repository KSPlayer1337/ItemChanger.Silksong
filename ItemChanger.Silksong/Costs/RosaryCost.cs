using ItemChanger.Costs;
using ItemChanger.Silksong.Extensions;

namespace ItemChanger.Silksong.Costs;

public class RosaryCost(int Amount) : Cost, ICurrencyCost
{
    /// <summary>
    /// Amount after accounting for any discount rate.
    /// </summary>
    public int ActualAmount => (int)(Amount * base.DiscountRate);

    public override bool CanPay() => PlayerData.instance.GetInt(nameof(PlayerData.geo)) >= ActualAmount;

    public override string GetCostText() => RawData.ItemChangerLanguageStrings.CreatePayRosariesString(ActualAmount.ToValueProvider()).Value;

    public override bool HasPayEffects() => true;

    public override void OnPay()
    {
        if (ActualAmount > 0) HeroController.instance.TakeGeo(ActualAmount);
    }

    public override bool IsFree => ActualAmount <= 0;

    int ICurrencyCost.Amount => ActualAmount;

    CurrencyType ICurrencyCost.CurrencyType => CurrencyType.Money;
}
