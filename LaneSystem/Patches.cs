using HarmonyLib;

namespace C2VM.CommonLibraries.LaneSystem;

[HarmonyPatch]
class Patches
{
    [HarmonyPatch(typeof(Game.Common.SystemOrder), "Initialize")]
    [HarmonyPostfix]
    static void Initialize(Game.UpdateSystem updateSystem)
    {
        updateSystem.UpdateAt<Game.Net.C2VMPatchedLaneSystem>(Game.SystemUpdatePhase.Modification4);
    }

    [HarmonyPatch(typeof(Game.Net.LaneSystem), "OnCreate")]
    [HarmonyPrefix]
    static bool OnCreate(Game.Net.LaneSystem __instance)
    {
        return false;
    }

    [HarmonyPatch(typeof(Game.Net.LaneSystem), "OnUpdate")]
    [HarmonyPrefix]
    static bool OnUpdate(Game.Net.LaneSystem __instance)
    {
        return false;
    }
}