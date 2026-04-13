using Benchwarp.Data;
using ItemChanger;
using ItemChanger.Costs;
using ItemChanger.Locations;
using ItemChanger.Serialization;
using ItemChanger.Silksong.Costs;
using ItemChanger.Silksong.RawData;
using ItemChanger.Silksong.StartDefs;
using ItemChanger.Tags;

namespace ItemChangerTesting.MiscTests;

internal class YNShinyTest : Test
{
    public override TestMetadata GetMetadata() => new()
    {
        Folder = TestFolder.MiscTests,
        MenuName = "YN Shinies",
        MenuDescription = "Tests YN Shinies",
        Revision = 2026041200,
    };

    public override void Setup(TestArgs args)
    {
        StartAt(new CoordinateStartDef() { SceneName = SceneNames.Bonetown, X = 60, Y = 7.57f });

        int pos = 60;

        Location GetNewLocation()
        {
            pos += 5;

            return new CoordinateLocation()
            {
                X = pos,
                Y = 7.57f,
                Managed = false,
                SceneName = SceneNames.Bonetown,
                Name = $"Bonetown shiny {pos}",
            };
        }

        Profile.AddPlacement(GetNewLocation().Wrap().WithDebugItem(persistence: ItemChanger.Enums.Persistence.Persistent));

        void TestCost(Cost cost)
        {
            Profile.AddPlacement(GetNewLocation().WithTag(new DefaultCostTag() { Cost = cost }).Wrap().WithDebugItem(persistence: ItemChanger.Enums.Persistence.Persistent));
        }

        TestCost(new RosaryCost(100));
        TestCost(new RosaryCost(1000));
        TestCost(new RosaryCost(10000));

        TestCost(new PDBoolCost(nameof(PlayerData.hasNeedolin), new BoxedString("Have Needolin")));
        TestCost(new DisplayablePDBoolCost(nameof(PlayerData.hasNeedolin), new BoxedString("Have Needolin"), BaseAtlasSprites.Needolin));

        TestCost(new RosaryCost(100) + new PDBoolCost(nameof(PlayerData.hasNeedolin), new BoxedString("Have Needolin")));
        TestCost(new RosaryCost(100) + new DisplayablePDBoolCost(nameof(PlayerData.hasNeedolin), new BoxedString("Have Needolin"), BaseAtlasSprites.Needolin));
    }
}
