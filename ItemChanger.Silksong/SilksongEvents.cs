using System.Collections.Generic;
using HarmonyLib;

namespace ItemChanger.Silksong;

public static class SilksongEvents
{
    public const string Wildcard = "*";

    /// Registers a delegate to run whenever a FSM matching the given
    /// (scene name, object name, FSM name) tuple is loaded.
    /// The scene and object names can be Wildcard ("*") instead to match any scene or any
    /// object, respectively.
    public static void AddFsmEdit(FsmId id, Action<PlayMakerFSM> edit)
    {
        edits[id] = edits.GetValueOrDefault(id) + edit;
    }

    public static void RemoveFsmEdit(FsmId id, Action<PlayMakerFSM> edit)
    {
        edits[id] -= edit;
    }

    internal static void Hook()
    {
        var patch = typeof(Patches);
        new Harmony(patch.FullName).PatchAll(patch);
    }

    internal static void Unhook()
    {
        Harmony.UnpatchID(typeof(Patches).FullName);
        foreach (var id in edits.Keys)
        {
            Logger.LogWarn($"FSM edit not cleaned up for {id.FsmName} in object {id.ObjectName} in scene {id.SceneName}");
        }
        edits.Clear();
    }

    private static Dictionary<FsmId, Action<PlayMakerFSM>?> edits = [];

    [HarmonyPatch]
    private static class Patches
    {
        [HarmonyPatch(typeof(PlayMakerFSM), nameof(PlayMakerFSM.Start))]
        [HarmonyPrefix]
        private static void Prefix(PlayMakerFSM __instance)
        {
            var fsm = __instance;
            var sceneName = fsm.gameObject.scene.name;
            var objectName = fsm.gameObject.name;
            var fsmName = fsm.FsmName;
            List<FsmId> matchingIds = [
                new(sceneName, objectName, fsmName),
                new(Wildcard, objectName, fsmName),
                new(sceneName, Wildcard, fsmName),
                new(Wildcard, Wildcard, fsmName)
            ];
            try
            {
                foreach (const id in matchingIds)
                {
                    edits.GetValueOrDefault(id)?.Invoke(fsm);
                }
            }
            catch (Exception err)
            {
                Logger.LogError($"Error applying FSM edit to FSM {id.FsmName} in object {id.ObjectName} in scene {id.SceneName}: {err}");
            }
        }
    }
}