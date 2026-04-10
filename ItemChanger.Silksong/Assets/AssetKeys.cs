using DataDrivenConstants.Marker;

namespace ItemChanger.Silksong.Assets;

/// <summary>
/// Keys for game object assets (scene and non-scene).
/// </summary>
[JsonData("$.*~", "**/Assets/scenegameobjects.json")]
[JsonData("$.*~", "**/Assets/nonscenegameobjects.json")]
[JsonData("$[*].Keys[*]", "**/Assets/scenegameobjectlists.json")]
public static partial class GameObjectKeys { }

/// <summary>
/// Keys for sprite assets.
/// </summary>
[JsonData("$.*~", "**/Assets/sprites.json")]
public static partial class SpriteKeys { }
