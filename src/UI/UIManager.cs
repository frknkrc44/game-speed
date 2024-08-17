
using System;
using System.IO;
using BepInEx;
using GameSpeed.UI.Panels;
using UnityEngine;
using UniverseLib;
using UniverseLib.UI;

namespace GameSpeed.UI;

public class UIManager {
    public static UIBase UiBase { get; private set; }
    public static SpeedPanel SpeedPanel { get; private set; }
    private static Action onInitAction;
    public static GameObject UIRoot => UiBase?.RootObject;

    internal static void Initialize(Action onInit) {
        onInitAction = onInit;

        const float startupDelay = 3f;
        UniverseLib.Config.UniverseLibConfig config = new() {
            Disable_EventSystem_Override = false,
            Force_Unlock_Mouse = false,
            Allow_UI_Selection_Outside_UIBase = true,
            Unhollowed_Modules_Folder = Path.Combine(Paths.BepInExRootPath, "interop")
        };
        Universe.Init(startupDelay, LateInit, CustomLog, config);
    }

    static void UiUpdate() {
        // Called once per frame when your UI is being displayed.
    }

    private static void LateInit() {
        var unixTimestamp = (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
        UiBase = UniversalUI.RegisterUI(unixTimestamp.ToString(), UiUpdate);

        SpeedPanel = new SpeedPanel();

        onInitAction?.Invoke();
    }

    static void CustomLog(string message, LogType type) {
        Utils.Logger.Log.Trace(message);
    }
}
