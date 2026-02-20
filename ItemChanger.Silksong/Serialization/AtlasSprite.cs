using ItemChanger.Serialization;
using Newtonsoft.Json;
using Silksong.AssetHelper.Core;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.U2D;

namespace ItemChanger.Silksong.Serialization;

public static class AtlasSpriteBundleRegistry
{
    private static readonly HashSet<string> _bundleNames = [];

    private static readonly Dictionary<string, AsyncOperationHandle<IAssetBundleResource>> _bundleHandles = [];

    private static bool _loaded = false;

    public static void RegisterBundle(string bundleName)
    {
        _bundleNames.Add(bundleName);

        if (_loaded && !_bundleHandles.ContainsKey(bundleName))
        {
            _bundleHandles.Add(bundleName, LoadOne(bundleName));
        }
    }

    public static AssetBundle RetrieveBundle(string bundleName)
    {
        if (!_loaded)
        {
            throw new InvalidOperationException("Cannot retrieve bundles while not loaded!");
        }

        AsyncOperationHandle<IAssetBundleResource> handle = _bundleHandles[bundleName];
        if (!handle.IsDone)
        {
            handle.WaitForCompletion();
        }

        return handle.Result.GetAssetBundle();
    }

    private static AsyncOperationHandle<IAssetBundleResource> LoadOne(string bundleName)
    {
        string bundleKey = AddressablesData.ToBundleKey(bundleName);
        return Addressables.LoadAssetAsync<IAssetBundleResource>(bundleKey);
    }

    private static void LoadAll()
    {
        if (_loaded)
        {
            ItemChangerPlugin.Instance.Logger.LogWarning($"{nameof(AtlasSpriteBundleRegistry)}.{nameof(LoadAll)} called multiple times!");
            return;
        }

        foreach (string bundle in _bundleNames)
        {
            _bundleHandles[bundle] = LoadOne(bundle);
        }
        _loaded = true;
    }

    private static void UnloadAll()
    {
        foreach (AsyncOperationHandle<IAssetBundleResource> handle in _bundleHandles.Values)
        {
            Addressables.Release(handle);
        }

        _bundleHandles.Clear();
        _loaded = false;
    }

    internal static void Hook(ItemChangerHost host)
    {
        host.LifecycleEvents.OnEnterGame += LoadAll;
        host.LifecycleEvents.OnLeaveGame += UnloadAll;
    }
}

/// <summary>
/// Sprite provider which loads a sprite from a sprite atlas in one of the base game bundles.
/// </summary>
public class AtlasSprite : IValueProvider<Sprite>
{
    /// <summary>
    /// The path to the asset bundle, with forward slashes separating directories and ending ".bundle".
    /// 
    /// For example, "atlases_assets_assets/sprites/_atlases/fayforn_after_sit.spriteatlas.bundle".
    /// </summary>
    public required string BundleName
    {
        get => field;
        set
        {
            field = value;
            AtlasSpriteBundleRegistry.RegisterBundle(value);
        }
    }

    /// <summary>
    /// The name of the SpriteAtlas within the bundle. This can be "Assets/Sprites/_Atlases/Fayforn_after_sit.spriteatlas"
    /// </summary>
    public string? AtlasName { get; init; }

    public required string SpriteName { get; init; }

    [JsonIgnore]
    public Sprite Value
    {
        get
        {
            AssetBundle bundle = AtlasSpriteBundleRegistry.RetrieveBundle(BundleName);

            string atlasName;
            if (AtlasName != null)
            {
                atlasName = AtlasName;
            }
            else
            {
                string[] names = bundle.GetAllAssetNames();
                if (names.Length == 1)
                {
                    atlasName = names[0];
                }
                else
                {
                    throw new ArgumentException($"Found {names.Length} assets in the bundle {BundleName}! The asset name must be specified.");
                }
            }
            
            SpriteAtlas atlas = bundle.LoadAsset<SpriteAtlas>(atlasName);
            Sprite sprite = atlas.GetSprite(SpriteName);

            return sprite;
        }
    }
}
