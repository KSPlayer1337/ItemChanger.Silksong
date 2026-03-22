using Benchwarp.Util;
using ItemChanger.Silksong.Util;
using Silksong.AssetHelper.ManagedAssets;

namespace ItemChanger.Silksong.Assets;

/// <summary>
/// Special case (non-generic) for GameObjects because there
/// may be special case code.
/// </summary>
internal class GameObjectCache : IObjectCache<GameObject>
{
    private Dictionary<string, ManagedAsset<GameObject>> _assets = [];

    public GameObject GetAsset(string key)
    {
        // TODO - if using something like a ManagedAssetList to load an asset, special case it here.

        if (_assets.TryGetValue(key, out ManagedAsset<GameObject> asset))
        {
            asset.EnsureLoaded();
            return asset.Handle.Result;
        }

        throw new ArgumentException($"GameObject asset with key {key} not recognized");
    }

    public GameObjectCache()
    {
        // Load scene assets
        if (!JsonUtils.TryDeserializeEmbeddedResource(
            "ItemChanger.Silksong.Resources.Assets.scenegameobjects.json",
            out Dictionary<string, ManagedAssetGroup<GameObject>.SceneAssetInfo>? sceneAssetData))
        {
            throw new ArgumentException($"Could not find scene game objects resource");
        }

        foreach ((string key, ManagedAssetGroup<GameObject>.SceneAssetInfo info) in sceneAssetData)
        {
            _assets[key] = ManagedAsset<GameObject>.FromSceneAsset(sceneName: info.SceneName, objPath: info.ObjPath);
        }

        // Load non-scene assets
        if (!JsonUtils.TryDeserializeEmbeddedResource(
            "ItemChanger.Silksong.Resources.Assets.nonscenegameobjects.json",
            out Dictionary<string, ManagedAssetGroup<GameObject>.NonSceneAssetInfo>? nonSceneAssetData))
        {
            throw new ArgumentException($"Could not find non-scene game objects resource");
        }


        foreach ((string key, ManagedAssetGroup<GameObject>.NonSceneAssetInfo info) in nonSceneAssetData)
        {
            _assets[key] = ManagedAsset<GameObject>.FromNonSceneAsset(assetName: info.AssetName, bundleName: info.BundleName);
        }
    }

    public void Load()
    {
        foreach (ManagedAsset<GameObject> asset in _assets.Values)
        {
            asset.Load();
        }
    }

    public void Unload()
    {
        foreach (ManagedAsset<GameObject> asset in _assets.Values)
        {
            asset.Unload();
        }
    }
}
