using HarmonyLib;

namespace C2VM.CommonLibraries.LaneSystem;

[HarmonyPatch]
class Patches
{
    [HarmonyPatch(typeof(Game.Net.LaneSystem), "OnCreate")]
    [HarmonyPrefix]
    static bool OnCreate(Game.Net.LaneSystem __instance)
    {
        __instance.World.GetOrCreateSystemManaged<Game.Net.C2VMPatchedLaneSystem>();
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
        __instance.World.GetOrCreateSystemManaged<Game.Net.C2VMPatchedLaneSystem>().Update();
        return false;
    }
}