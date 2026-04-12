using ItemChanger.Costs;
using ItemChanger.Silksong.Modules;
using UnityEngine;

namespace ItemChanger.Silksong.Components;

/// <summary>
/// Component causing a YN box to be displayed when the object is interacted with.
/// </summary>
[RequireComponent(typeof(InteractEvents))]
public class CustomYNBoxInfo : MonoBehaviour
{
    public Cost Cost;
    public Func<string> TextGetter;
}
