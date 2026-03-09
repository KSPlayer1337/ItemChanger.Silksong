using ItemChanger.Items;
using ItemChanger.Silksong.Modules.CustomSkills;

namespace ItemChanger.Silksong.Items;

public class CustomSkillItem : Item
{
    /// <summary>
    /// The skill bool associated with the custom skill, to be set true in <see cref="CustomSkillModule.SetBool(string, bool)"/>.
    /// </summary>
    public required string BoolName { get; init; }
    /// <summary>
    /// The name of the type of <see cref="CustomSkillModule"/> required by the item, suitable for usage in Type.GetType.
    /// </summary>
    public required string ModuleTypeName { get; init; }

    protected CustomSkillModule Module
    {
        get
        {
            Type? modType = Type.GetType(ModuleTypeName);
            if (modType is null || !modType.IsSubclassOf(typeof(CustomSkillModule)))
            {
                throw new InvalidOperationException($"Unable to locate CustomSkillModule with type name {ModuleTypeName}");
            }
            return (CustomSkillModule)ActiveProfile!.Modules.GetOrAdd(modType);
        }
    }

    protected override void DoLoad()
    {
        base.DoLoad();
        _ = Module;
    }

    public override void GiveImmediate(GiveInfo info)
    {
        PlayerData.instance.SetBool(BoolName, true);
    }

    public override bool Redundant()
    {
        return PlayerData.instance.GetBool(BoolName);
    }
}
