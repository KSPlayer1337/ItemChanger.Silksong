using ItemChanger.Costs;
using ItemChanger.Serialization;
using ItemChanger.Silksong.Serialization;
using System;

namespace ItemChanger.Silksong.Costs
{
    public class PDBoolCost(string BoolName, IValueProvider<string> CostText) : ThresholdBoolCost
    {
        private PDBool _pdBool = new(BoolName);

        public override string GetCostText()
        {
            return CostText.Value;
        }

        protected override IValueProvider<bool> GetValueSource()
        {
            return _pdBool;
        }
    }
}
