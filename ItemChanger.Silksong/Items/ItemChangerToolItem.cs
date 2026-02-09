using ItemChanger.Items;

namespace ItemChanger.Silksong.Items
{
    /// <summary>
    /// Item based on <see cref="ToolItem"/>.
    /// </summary>
    public class ItemChangerToolItem : Item
    {
        /// <summary>
        /// The <see cref="UObject.name"/> of the <see cref="ToolItem"/>.
        /// </summary>
        public required string CollectableName { get; init; }
        

        public override void GiveImmediate(GiveInfo info)
        {
            ToolItem tool = ToolItemManager.GetToolByName(CollectableName);
            tool.Get(showPopup: false); 
        }

        public override bool Redundant()
        {
            ToolItem tool = ToolItemManager.GetToolByName(CollectableName);
            return !tool.CanGetMore();
        }
    }
}
