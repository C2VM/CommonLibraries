using HarmonyLib;

namespace C2VM.CommonLibraries.LaneSystem;

[HarmonyPatch]
class Patches
{
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