using BepInEx;
using BepInEx.Unity.IL2CPP;
using GameSpeed.Systems;
using GameSpeed.UI;
using HarmonyLib;
using UnityEngine;

namespace GameSpeed;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]

public class Plugin : BasePlugin {
    private static Harmony harmony;

    public override void Load() {
        Settings.Config.Load(Config, Log, "Client");

        UIManager.Initialize(() => {
            Time.timeScale = Hooks.TimePatch.originalTimeScale;
        });
        AddComponent<KeyBindsBehaviour>();

        harmony = new Harmony(MyPluginInfo.PLUGIN_GUID);

        Utils.Logger.Log.Trace("Patching harmony");
        harmony.PatchAll();

        Utils.Logger.Log.Info($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");
    }
}
