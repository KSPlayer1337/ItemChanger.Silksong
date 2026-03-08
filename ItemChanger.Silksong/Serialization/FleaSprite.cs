using GlobalSettings;
using ItemChanger.Serialization;
using Newtonsoft.Json;
using UnityEngine;

namespace ItemChanger.Silksong.Serialization;

public class FleaSprite : IValueProvider<Sprite>
{
    [JsonIgnore] public Sprite Value => Gameplay.FleasCollectedCounter.GetPopupIcon();
}
