using GlobalSettings;
using ItemChanger.Serialization;
using Newtonsoft.Json;

namespace ItemChanger.Silksong.Serialization;

/// <summary>
/// Int provider that returns the fleas collected count as returned by the
/// <see cref="QuestTargetPlayerDataBools" /> saved item.
/// </summary>
public class FleaCount : IValueProvider<int>
{
    [JsonIgnore] public int Value => Gameplay.FleasCollectedCount;
}
