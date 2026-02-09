using ItemChanger.Items;

namespace ItemChanger.Silksong.Items
{
    /// <summary>
    /// Item based on <see cref="ToolItem"/> for Silk Skills, which sets an additional PD bool normally set by fsm.
    /// </summary>
    public class ItemChangerToolItemSkill : Item
    {
        /// <summary>
        /// The <see cref="UObject.name"/> of the <see cref="ToolItem"/> for Silk Skills.
        /// </summary>
        public required string CollectableName { get; init; }
        public required string BoolName { get; init; }


        public override void GiveImmediate(GiveInfo info)
        {
            ToolItem tool = ToolItemManager.GetToolByName(CollectableName);
            PlayerData.instance.SetBool(BoolName, true);
            tool.Get(showPopup: false);
        }

        public override bool Redundant()
        {
            ToolItem tool = ToolItemManager.GetToolByName(CollectableName);
            return !tool.CanGetMore() && PlayerData.instance.GetBool(BoolName);
        }
    }
}
