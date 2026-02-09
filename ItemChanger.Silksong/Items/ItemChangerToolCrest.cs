using ItemChanger.Items;

namespace ItemChanger.Silksong.Items
{
    /// <summary>
    /// Item based on <see cref="ToolCrest"/>.
    /// </summary>
    public class ItemChangerToolCrest : Item
    {
        /// <summary>
        /// The <see cref="UObject.name"/> of the <see cref="ToolCrest"/>.
        /// </summary>
        public required string CollectableName { get; init; }
        

        public override void GiveImmediate(GiveInfo info)
        {
            ToolCrest crest = ToolItemManager.GetCrestByName(CollectableName);
            crest.Get(showPopup: false);
        }

        public override bool Redundant()
        {
            ToolCrest crest = ToolItemManager.GetCrestByName(CollectableName);
            return !crest.CanGetMore();
        }
    }
}
