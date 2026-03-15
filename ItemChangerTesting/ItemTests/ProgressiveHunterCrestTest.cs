using Benchwarp.Data;
using ItemChanger;
using ItemChanger.Locations;
using ItemChanger.Silksong.RawData;

namespace ItemChangerTesting.ItemTests;

internal class ProgressiveHunterCrestTest : Test
{
    public override TestMetadata GetMetadata() => new()
    {
        Folder = TestFolder.ItemTests,
        MenuName = "Progressive Hunter Crest",
        MenuDescription = "Tests giving 3 Progressive Hunter Crest items from coordinate shinies via ItemChainTag.",
        Revision = 2026030200,
    };

    public override void Setup(TestArgs args)
    {
        StartNear(SceneNames.Tut_02, PrimitiveGateNames.right1);
        Profile.AddPlacement(new CoordinateLocation
        {
            Name = "Progressive Hunter Crest 1 (left)",
            SceneName = SceneNames.Tut_02,
            X = 130.6f,
            Y = 31.57f,
            FlingType = ItemChanger.Enums.FlingType.Everywhere,
            Managed = false,
        }.Wrap().Add(Finder.GetItem(ItemNames.Crest_of_Hunter)!));
        Profile.AddPlacement(new CoordinateLocation
        {
            Name = "Progressive Hunter Crest 2 (middle)",
            SceneName = SceneNames.Tut_02,
            X = 133.6f,
            Y = 31.57f,
            FlingType = ItemChanger.Enums.FlingType.Everywhere,
            Managed = false,
        }.Wrap().Add(Finder.GetItem(ItemNames.Crest_of_Hunter)!));
        Profile.AddPlacement(new CoordinateLocation
        {
            Name = "Progressive Hunter Crest 3 (right)",
            SceneName = SceneNames.Tut_02,
            X = 136.6f,
            Y = 31.57f,
            FlingType = ItemChanger.Enums.FlingType.Everywhere,
            Managed = false,
        }.Wrap().Add(Finder.GetItem(ItemNames.Crest_of_Hunter)!));
        Profile.AddPlacement(new CoordinateLocation
        {
            Name = "Wanderer Crest (far left)",
            SceneName = SceneNames.Tut_02,
            X = 127.6f,
            Y = 31.57f,
            FlingType = ItemChanger.Enums.FlingType.Everywhere,
            Managed = false,
        }.Wrap().Add(Finder.GetItem(ItemNames.Crest_of_Wanderer)!));
    }
}
