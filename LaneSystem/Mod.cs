using System.Reflection;
using Colossal.Logging;
using Game;
using Game.Modding;
using Game.SceneFlow;
using HarmonyLib;

namespace C2VM.CommonLibraries.LaneSystem;

public class Mod : IMod
{
    public static string id = typeof(Mod).Assembly.GetName().Name;

    public static ILog log = LogManager.GetLogger($"{id}.{nameof(Mod)}").SetShowsErrorsInUI(false);

    public void OnLoad(UpdateSystem updateSystem)
    {
        string informationalVersion = ((AssemblyInformationalVersionAttribute) System.Attribute.GetCustomAttribute(Assembly.GetAssembly(typeof(Mod)), typeof(AssemblyInformationalVersionAttribute))).InformationalVersion;

        log.Info($"Loading {id} v{informationalVersion}");

        if (GameManager.instance.modManager.TryGetExecutableAsset(this, out var asset))
        {
            log.Info($"Current mod asset at {asset.path}");
        }

        var harmony = new Harmony(id);
        harmony.PatchAll();

        updateSystem.UpdateBefore<Game.Net.C2VMPatchedLaneSystem, Game.Net.LaneSystem>(Game.SystemUpdatePhase.Modification4);
    }

    public void OnDispose()
    {
        log.Info(nameof(OnDispose));
    }
}