using ItemChanger.Modules;
using HutongGames.PlayMaker;
using Benchwarp.Data;
using Silksong.FsmUtil;

namespace ItemChanger.Silksong.Modules;

/// <summary>
/// Module that forces certain obstacles - such as chapel doors - to be open when they would
/// otherwise be closed after obtaining the vanilla items behind them.
/// 
/// This module is included by default in new ItemChanger profiles; IC clients should usually
/// not remove it or reduce the set of suppressed obstacles, as other clients may introduce
/// additional locations behind them.
/// </summary>
[SingletonModule]
public class ObstacleSuppressionModule : Module
{
    /// <summary>
    /// The set of possible obstacles that may be affected by this module.
    /// </summary>
    public enum Obstacle
    {
        /// <summary>
        /// The door to the Chapel of the Reaper.
        /// </summary>
        ChapelReaper,
        /// <summary>
        /// The door to the Chapel of the Beast.
        /// </summary>
        ChapelBeast,
        /// <summary>
        /// The door to the Chapel of the Wanderer.
        /// </summary>
        ChapelWanderer,
        /// <summary>
        /// The door to the Chapel of the Architect.
        /// The Architect Key is still required to open the door.
        /// </summary>
        ChapelArchitect,
    }

    /// <summary>
    /// The set of obstacles to force open.
    /// </summary>
    public List<Obstacle> Obstacles = [
        Obstacle.ChapelReaper,
        Obstacle.ChapelBeast,
        Obstacle.ChapelWanderer,
        Obstacle.ChapelArchitect
    ];

    private readonly Dictionary<Obstacle, Func<IDisposable>> _availableEdits = new()
    {
        {Obstacle.ChapelReaper, () => new FsmEditGroup { {new(SceneNames.Greymoor_20b, "Chapel Door Control", "chapel_door_control"), ForceDoorOpen("REAPER") } } },
        {Obstacle.ChapelBeast, () => new FsmEditGroup { {new(SceneNames.Ant_20, "Chapel Door Control", "chapel_door_control"), ForceDoorOpen("WARRIOR") } } },
        {Obstacle.ChapelWanderer, () => new FsmEditGroup { {new(SceneNames.Bonegrave, "Chapel Door Control", "chapel_door_control"), ForceDoorOpen("WANDERER") } } },
        {Obstacle.ChapelArchitect, () => new FsmEditGroup { {new(SceneNames.Under_17, "Architect Shrine Door", "FSM"), ForceArchitectDoorOpen } } },
    };

    protected override void DoLoad()
    {
        foreach (Obstacle obs in Obstacles)
        {
            if (_availableEdits.TryGetValue(obs, out Func<IDisposable> createEdit))
            {
                Using(createEdit());
            }
        }
    }

    protected override void DoUnload() {}

    // Removing the FSM entirely would be sufficient to let the player through the door,
    // but leaves it impassable after coming back out.

    private static System.Action<PlayMakerFSM> ForceDoorOpen(string transName)
    {
        return fsm =>
        {
            FsmState state = fsm.MustGetState("Crest Check");
            state.RemoveTransition(transName);
            state.AddTransition(transName, "Open");
        };
    }

    private static void ForceArchitectDoorOpen(PlayMakerFSM fsm)
    {
        FsmState unlockedState = fsm.MustGetState("Unlocked");
        string finishEntryTrans = "FINISH ENTRY";
        unlockedState.RemoveTransition(finishEntryTrans);
        unlockedState.AddTransition(finishEntryTrans, "Stay");

        FsmState entryState = fsm.MustGetState("Entry from this gate?");
        string falseTrans = "FALSE";
        entryState.RemoveTransition(falseTrans);
        entryState.AddTransition(falseTrans, "Unlocked");
    }
}