using HarmonyLib;

namespace C2VM.CommonLibraries.LaneSystem;

[HarmonyPatch]
class Patches
{
    [HarmonyPatch(typeof(Game.Net.LaneSystem), "OnCreate")]
    [HarmonyPrefix]
    static bool OnCreate(Game.Net.LaneSystem __instance)
    {
        __instance.World.GetOrCreateSystemManaged<Game.Net.PatchedLaneSystem>();
        __instance.World.GetOrCreateSystemManaged<Game.UpdateSystem>().UpdateAt<Game.Net.PatchedLaneSystem>(Game.SystemUpdatePhase.GameSimulation);
        return true;
    }

    [HarmonyPatch(typeof(Game.Net.LaneSystem), "OnCreateForCompiler")]
    [HarmonyPrefix]
    static bool OnCreateForCompiler()
    {
        return false;
    }

    [HarmonyPatch(typeof(Game.Net.LaneSystem), "OnUpdate")]
    [HarmonyPrefix]
    static bool OnUpdate(Game.Net.LaneSystem __instance)
    {
        __instance.World.GetOrCreateSystemManaged<Game.Net.PatchedLaneSystem>().Update();
        return false;
    }
}