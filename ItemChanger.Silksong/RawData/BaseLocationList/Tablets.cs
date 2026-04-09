using Benchwarp.Data;
using ItemChanger.Locations;
using ItemChanger.Silksong.Containers;
using ItemChanger.Tags;

namespace ItemChanger.Silksong.RawData;

internal static partial class BaseLocationList
{
    public static Location Lore_Tablet__Abyss_Top => new ObjectLocation()
    {
        Name = LocationNames.Lore_Tablet__Abyss_Top,
        SceneName = SceneNames.Abyss_02b,
        ObjectName = "Abyss_lore_stone/Inspect Region",
        Correction = default,
        Tags = [
            new OriginalContainerTag() { ContainerType = ContainerNames.Tablet, Force = true }
            ]
    };

    public static Location Lore_Tablet__Abyss_Bottom_Left => new ObjectLocation()
    {
        Name = LocationNames.Lore_Tablet__Abyss_Bottom_Left,
        SceneName = SceneNames.Abyss_06,
        ObjectName = "Abyss_lore_stone/Inspect Region",
        Correction = default,
        Tags = [
            new OriginalContainerTag() { ContainerType = ContainerNames.Tablet, Force = true }
            ]
    };

    /*
    public static Location Lore_Tablet__Fleatopia_Weaver_Harp => new ObjectLocation()
    {
        Name = LocationNames.Lore_Tablet__Fleatopia_Weaver_Harp,
        SceneName = SceneNames.Aqueduct_05_*,
        ObjectName = "Caravan_States/Fleatopia/weaver_harp_sign (2)/Inspect Region",
        Correction = default,
        Tags = [
            new OriginalContainerTag() { ContainerType = ContainerNames.Tablet, Force = true }
            ]
    };
    */

    public static Location Lore_Tablet__Memorium_Entrance => new ObjectLocation()
    {
        Name = LocationNames.Lore_Tablet__Memorium_Entrance,
        SceneName = SceneNames.Arborium_01,
        ObjectName = "Inspect Region",
        Correction = default,
        Tags = [
            new OriginalContainerTag() { ContainerType = ContainerNames.Tablet, Force = true }
            ]
    };

    public static Location Lore_Tablet__Memorium_Orders => new ObjectLocation()
    {
        Name = LocationNames.Lore_Tablet__Memorium_Orders,
        SceneName = SceneNames.Arborium_03,
        ObjectName = "Inspect Region",
        Correction = default,
        Tags = [
            new OriginalContainerTag() { ContainerType = ContainerNames.Tablet, Force = true }
            ]
    };

    public static Location Lore_Tablet__Bellhart_East => new ObjectLocation()
    {
        Name = LocationNames.Lore_Tablet__Bellhart_East,
        SceneName = SceneNames.Belltown_06,
        ObjectName = "Inspect Region",
        Correction = default,
        Tags = [
            new OriginalContainerTag() { ContainerType = ContainerNames.Tablet, Force = true }
            ]
    };

    public static Location Lore_Tablet__Bellhart_West => new ObjectLocation()
    {
        Name = LocationNames.Lore_Tablet__Bellhart_West,
        SceneName = SceneNames.Belltown_07,
        ObjectName = "Black Thread States Thread Only Variant/Normal World/Inspect Region",
        Correction = default,
        Tags = [
            new OriginalContainerTag() { ContainerType = ContainerNames.Tablet, Force = true }
            ]
    };

    public static Location Lore_Tablet__Marrow_Start => new ObjectLocation()
    {
        Name = LocationNames.Lore_Tablet__Marrow_Start,
        SceneName = SceneNames.Bone_01c,
        ObjectName = "Inspect Region",
        Correction = default,
        Tags = [
            new OriginalContainerTag() { ContainerType = ContainerNames.Tablet, Force = true }
            ]
    };

    public static Location Lore_Tablet__Marrow_Top => new ObjectLocation()
    {
        Name = LocationNames.Lore_Tablet__Marrow_Top,
        SceneName = SceneNames.Bone_18,
        ObjectName = "Inspect Region",
        Correction = default,
        Tags = [
            new OriginalContainerTag() { ContainerType = ContainerNames.Tablet, Force = true }
            ]
    };

    public static Location Lore_Tablet__Pilgrims_Rest => new ObjectLocation()
    {
        Name = LocationNames.Lore_Tablet__Pilgrims_Rest,
        SceneName = SceneNames.Bone_East_10,
        ObjectName = "Black Thread States Thread Only Variant/Normal World/Group/Inspect Region",
        Correction = default,
        Tags = [
            new OriginalContainerTag() { ContainerType = ContainerNames.Tablet, Force = true }
            ]
    };

    public static Location Lore_Tablet__Weavenest_Cindril => new ObjectLocation()
    {
        Name = LocationNames.Lore_Tablet__Weavenest_Cindril,
        SceneName = SceneNames.Bone_East_Weavehome,
        ObjectName = "Group/Inspect Region (2)",
        Correction = default,
        Tags = [
            new OriginalContainerTag() { ContainerType = ContainerNames.Tablet, Force = true }
            ]
    };

    public static Location Lore_Tablet__Verdania_End => new ObjectLocation()
    {
        Name = LocationNames.Lore_Tablet__Verdania_End,
        SceneName = SceneNames.Clover_10,
        ObjectName = "Plaque_Scene/Plaque/Inspect Region",
        Correction = default,
        Tags = [
            new OriginalContainerTag() { ContainerType = ContainerNames.Tablet, Force = true }
            ]
    };

    public static Location Lore_Tablet__Verdania_Fountains => new ObjectLocation()
    {
        Name = LocationNames.Lore_Tablet__Verdania_Fountains,
        SceneName = SceneNames.Clover_18,
        ObjectName = "Fountains Group/Plaque/Up/Inspect Region",
        Correction = default,
        Tags = [
            new OriginalContainerTag() { ContainerType = ContainerNames.Tablet, Force = true }
            ]
    };

    public static Location Lore_Tablet__Blasted_Steps_Start => new ObjectLocation()
    {
        Name = LocationNames.Lore_Tablet__Blasted_Steps_Start,
        SceneName = SceneNames.Coral_19,
        ObjectName = "Black Thread States Thread Only Variant/Normal World/Inspect Region",
        Correction = default,
        Tags = [
            new OriginalContainerTag() { ContainerType = ContainerNames.Tablet, Force = true }
            ]
    };

    public static Location Lore_Tablet__Karak_Entrance => new ObjectLocation()
    {
        Name = LocationNames.Lore_Tablet__Karak_Entrance,
        SceneName = SceneNames.Coral_25,
        ObjectName = "Coral Crust Lore Tablet/Interact",
        Correction = default,
        Tags = [
            new OriginalContainerTag() { ContainerType = ContainerNames.Tablet, Force = true }
            ]
    };

    public static Location Lore_Tablet__Blasted_Steps_Nursery => new ObjectLocation()
    {
        Name = LocationNames.Lore_Tablet__Blasted_Steps_Nursery,
        SceneName = SceneNames.Coral_36,
        ObjectName = "Inspect Region",
        Correction = default,
        Tags = [
            new OriginalContainerTag() { ContainerType = ContainerNames.Tablet, Force = true }
            ]
    };

    public static Location Lore_Tablet__Coral_Tower => new ObjectLocation()
    {
        Name = LocationNames.Lore_Tablet__Coral_Tower,
        SceneName = SceneNames.Coral_Tower_01,
        ObjectName = "Coral Crust Lore Tablet/Interact",
        Correction = default,
        Tags = [
            new OriginalContainerTag() { ContainerType = ContainerNames.Tablet, Force = true }
            ]
    };

    public static Location Lore_Tablet__Cradle_Cage_1 => new ObjectLocation()
    {
        Name = LocationNames.Lore_Tablet__Cradle_Cage_1,
        SceneName = SceneNames.Cradle_02b,
        ObjectName = "Inspect Region (1)",
        Correction = default,
        Tags = [
            new OriginalContainerTag() { ContainerType = ContainerNames.Tablet, Force = true }
            ]
    };

    public static Location Lore_Tablet__Cradle_Cage_2 => new ObjectLocation()
    {
        Name = LocationNames.Lore_Tablet__Cradle_Cage_2,
        SceneName = SceneNames.Cradle_02b,
        ObjectName = "Inspect Region",
        Correction = default,
        Tags = [
            new OriginalContainerTag() { ContainerType = ContainerNames.Tablet, Force = true }
            ]
    };

    public static Location Lore_Tablet__Cradle_Cage_3 => new ObjectLocation()
    {
        Name = LocationNames.Lore_Tablet__Cradle_Cage_3,
        SceneName = SceneNames.Cradle_02b,
        ObjectName = "Inspect Region (2)",
        Correction = default,
        Tags = [
            new OriginalContainerTag() { ContainerType = ContainerNames.Tablet, Force = true }
            ]
    };

    public static Location Lore_Tablet__Greymoor_Orders_Above_Home => new ObjectLocation()
    {
        Name = LocationNames.Lore_Tablet__Greymoor_Orders_Above_Home,
        SceneName = SceneNames.Greymoor_03,
        ObjectName = "Inspect Region",
        Correction = default,
        Tags = [
            new OriginalContainerTag() { ContainerType = ContainerNames.Tablet, Force = true }
            ]
    };

    public static Location Lore_Tablet__Greymoor_Bottom => new ObjectLocation()
    {
        Name = LocationNames.Lore_Tablet__Greymoor_Bottom,
        SceneName = SceneNames.Greymoor_16,
        ObjectName = "Inspect Region",
        Correction = default,
        Tags = [
            new OriginalContainerTag() { ContainerType = ContainerNames.Tablet, Force = true }
            ]
    };

    /*
     * Note - datamining found a nuu scroll with the following parameters:
     * Location name: Lore_Tablet__Nuu_Scroll
     * SceneName: Halfway_01
     * ObjectName: "_NPCs/Hunter Fan Control/Nuu_Scrolls/Inspect Region"
     * Language: ("Wanderers", "HUNTER_FAN_SCROLL_INSPECT")
     * 
     * I don't believe it's viewable in-game so I'm not putting it in the location list
     */

    public static Location Lore_Tablet__Trobbio_Sign => new ObjectLocation()
    {
        Name = LocationNames.Lore_Tablet__Trobbio_Sign,
        SceneName = SceneNames.Library_13,
        ObjectName = "Grand Stage Scene/First_Stage/Post_defeat_set/trobbio_signpost/Inspect Region",
        Correction = default,
        Tags = [
            new OriginalContainerTag() { ContainerType = ContainerNames.Tablet, Force = true }
            ]
    };

    public static Location Lore_Tablet__Trobbio_Notes => new ObjectLocation()
    {
        Name = LocationNames.Lore_Tablet__Trobbio_Notes,
        SceneName = SceneNames.Library_13b,
        ObjectName = "Desk Inspect and Quill/Group/desk_inspect/Inspect Region Act 2",
        Correction = default,
        Tags = [
            new OriginalContainerTag() { ContainerType = ContainerNames.Tablet, Force = true }
            ]
    };

    public static Location Lore_Tablet__Tormented_Trobbio_Notes => new ObjectLocation()
    {
        Name = LocationNames.Lore_Tablet__Tormented_Trobbio_Notes,
        SceneName = SceneNames.Library_13b,
        ObjectName = "Desk Inspect and Quill/Group/desk_inspect/Inspect Region Act 3",
        Correction = default,
        Tags = [
            new OriginalContainerTag() { ContainerType = ContainerNames.Tablet, Force = true }
            ]
    };

    public static Location Lore_Tablet__Mosshome_Below_Silkspear => new ObjectLocation()
    {
        Name = LocationNames.Lore_Tablet__Mosshome_Below_Silkspear,
        SceneName = SceneNames.Mosstown_02,
        ObjectName = "lore_tablet/moss_bone_plaque/Inspect Region",
        Correction = default,
        Tags = [
            new OriginalContainerTag() { ContainerType = ContainerNames.Tablet, Force = true }
            ]
    };

    public static Location Lore_Tablet__Mosshome_Below_Silkspear_Harp => new ObjectLocation()
    {
        Name = LocationNames.Lore_Tablet__Mosshome_Below_Silkspear_Harp,
        SceneName = SceneNames.Mosstown_02,
        ObjectName = "lore_tablet/weaver_harp_sign/Inspect Region",
        Correction = default,
        Tags = [
            new OriginalContainerTag() { ContainerType = ContainerNames.Tablet, Force = true }
            ]
    };

    public static Location Lore_Tablet__Mount_Fay_Bottom => new ObjectLocation()
    {
        Name = LocationNames.Lore_Tablet__Mount_Fay_Bottom,
        SceneName = SceneNames.Peak_10,
        ObjectName = "Inspect Region (2)",
        Correction = default,
        Tags = [
            new OriginalContainerTag() { ContainerType = ContainerNames.Tablet, Force = true }
            ]
    };

    public static Location Lore_Tablet__Deep_Docks_Forge => new ObjectLocation()
    {
        Name = LocationNames.Lore_Tablet__Deep_Docks_Forge,
        SceneName = SceneNames.Room_Forge,
        ObjectName = "Inspect Region",
        Correction = default,
        Tags = [
            new OriginalContainerTag() { ContainerType = ContainerNames.Tablet, Force = true }
            ]
    };

    public static Location Lore_Tablet__Bilewater_Shortcut => new ObjectLocation()
    {
        Name = LocationNames.Lore_Tablet__Bilewater_Shortcut,
        SceneName = SceneNames.Shadow_08,
        ObjectName = "Inspect Region",
        Correction = default,
        Tags = [
            new OriginalContainerTag() { ContainerType = ContainerNames.Tablet, Force = true }
            ]
    };

    public static Location Lore_Tablet__Bilewater_Above_Groal => new ObjectLocation()
    {
        Name = LocationNames.Lore_Tablet__Bilewater_Above_Groal,
        SceneName = SceneNames.Shadow_18,
        ObjectName = "Inspect Region",
        Correction = default,
        Tags = [
            new OriginalContainerTag() { ContainerType = ContainerNames.Tablet, Force = true }
            ]
    };

    public static Location Lore_Tablet__Weavenest_Murglin => new ObjectLocation()
    {
        Name = LocationNames.Lore_Tablet__Weavenest_Murglin,
        SceneName = SceneNames.Shadow_Weavehome,
        ObjectName = "Inspect Region (1)",
        Correction = default,
        Tags = [
            new OriginalContainerTag() { ContainerType = ContainerNames.Tablet, Force = true }
            ]
    };

    public static Location Lore_Tablet__Shellwood_West => new ObjectLocation()
    {
        Name = LocationNames.Lore_Tablet__Shellwood_West,
        SceneName = SceneNames.Shellgrave,
        ObjectName = "Black Thread States Thread Only Variant/Normal World/Inspect Region",
        Correction = default,
        Tags = [
            new OriginalContainerTag() { ContainerType = ContainerNames.Tablet, Force = true }
            ]
    };

    public static Location Lore_Tablet__Shellwood_Harp => new ObjectLocation()
    {
        Name = LocationNames.Lore_Tablet__Shellwood_Harp,
        SceneName = SceneNames.Shellwood_10,
        ObjectName = "weaver_harp_sign/Inspect Region",
        Correction = default,
        Tags = [
            new OriginalContainerTag() { ContainerType = ContainerNames.Tablet, Force = true }
            ]
    };

    public static Location Lore_Tablet__Nyleth => new ObjectLocation()
    {
        Name = LocationNames.Lore_Tablet__Nyleth,
        SceneName = SceneNames.Shellwood_11b,
        ObjectName = "Inspect Region",
        Correction = default,
        Tags = [
            new OriginalContainerTag() { ContainerType = ContainerNames.Tablet, Force = true }
            ]
    };

    public static Location Lore_Tablet__Slab_Orders_1 => new ObjectLocation()
    {
        Name = LocationNames.Lore_Tablet__Slab_Orders_1,
        SceneName = SceneNames.Slab_08,
        ObjectName = "dock_b__0051_lore_sign_hang/Inspect Region",
        Correction = default,
        Tags = [
            new OriginalContainerTag() { ContainerType = ContainerNames.Tablet, Force = true }
            ]
    };

    public static Location Lore_Tablet__Slab_Orders_2 => new ObjectLocation()
    {
        Name = LocationNames.Lore_Tablet__Slab_Orders_2,
        SceneName = SceneNames.Slab_08,
        ObjectName = "dock_b__0051_lore_sign_hang (1)/Inspect Region",
        Correction = default,
        Tags = [
            new OriginalContainerTag() { ContainerType = ContainerNames.Tablet, Force = true }
            ]
    };

    public static Location Lore_Tablet__First_Sinner => new ObjectLocation()
    {
        Name = LocationNames.Lore_Tablet__First_Sinner,
        SceneName = SceneNames.Slab_10c,
        ObjectName = "Break Gate Group/Group/gate/Inspect Region",
        Correction = default,
        Tags = [
            new OriginalContainerTag() { ContainerType = ContainerNames.Tablet, Force = true }
            ]
    };

    public static Location Lore_Tablet__Ventrica_Hub => new ObjectLocation()
    {
        Name = LocationNames.Lore_Tablet__Ventrica_Hub,
        SceneName = SceneNames.Tube_Hub,
        ObjectName = "Black Thread States/Normal World/Inspect Region",
        Correction = default,
        Tags = [
            new OriginalContainerTag() { ContainerType = ContainerNames.Tablet, Force = true }
            ]
    };

    public static Location Lore_Tablet__Moss_Grotto_Chapel_Entrance => new ObjectLocation()
    {
        Name = LocationNames.Lore_Tablet__Moss_Grotto_Chapel_Entrance,
        SceneName = SceneNames.Tut_04,
        ObjectName = "Inspect Region",
        Correction = default,
        Tags = [
            new OriginalContainerTag() { ContainerType = ContainerNames.Tablet, Force = true }
            ]
    };

    public static Location Lore_Tablet__Moss_Grotto_Chapel_Inner => new ObjectLocation()
    {
        Name = LocationNames.Lore_Tablet__Moss_Grotto_Chapel_Inner,
        SceneName = SceneNames.Tut_05,
        ObjectName = "Inspect Region (1)",
        Correction = default,
        Tags = [
            new OriginalContainerTag() { ContainerType = ContainerNames.Tablet, Force = true }
            ]
    };

    public static Location Lore_Tablet__Whiteward_Oath => new ObjectLocation()
    {
        Name = LocationNames.Lore_Tablet__Whiteward_Oath,
        SceneName = SceneNames.Ward_07,
        ObjectName = "Group/Inspect Region",
        Correction = default,
        Tags = [
            new OriginalContainerTag() { ContainerType = ContainerNames.Tablet, Force = true }
            ]
    };

    public static Location Lore_Tablet__Weavenest_Atla_East => new ObjectLocation()
    {
        Name = LocationNames.Lore_Tablet__Weavenest_Atla_East,
        SceneName = SceneNames.Weave_08,
        ObjectName = "Group/Inspect Region (1)",
        Correction = default,
        Tags = [
            new OriginalContainerTag() { ContainerType = ContainerNames.Tablet, Force = true }
            ]
    };
}
