using ItemChanger.Items;

namespace ItemChanger.Silksong.Items
{
    /// <summary>
    /// Item based on <see cref="CollectableRelic"/>.
    /// </summary>
    public class ItemChangerCollectableRelic : Item
    {
        /// <summary>
        /// The <see cref="UObject.name"/> of the <see cref="CollectableRelic"/>.
        /// </summary>
        public required string CollectableName { get; init; }
        

        public override void GiveImmediate(GiveInfo info)
        {
            CollectableRelic relic = CollectableRelicManager.GetRelic(CollectableName);
            relic.Get(showPopup: false);
        }

        public override bool Redundant()
        {
            CollectableRelic relic = CollectableRelicManager.GetRelic(CollectableName);
            return !relic.CanGetMore();
        }
    }
}
