using System;
using GameSpeed.Settings;
using GameSpeed.UI;
using HarmonyLib;
using UnityEngine;
using Utils.Logger;

namespace GameSpeed.Hooks;

[HarmonyPatch]

public class TimePatch {
    internal static float originalTimeScale { get; private set; } = 1;

    [HarmonyPatch(typeof(Time), nameof(Time.timeScale), MethodType.Setter)]
    public static class SetTimeScale {
        public static bool Prefix(ref float value) {
            try {
                originalTimeScale = value;

                if (value != 0) {
                    if (ENV.Enabled.Value) {
                        if (ENV.UseValueSetterWorkaround.Value) {
                            value = ENV.DisabledSpeed.Value * ENV.Modifier.Value;
                        } else {
                            value *= ENV.Modifier.Value;
                        }

                        UIManager.SpeedPanel.SpeedLabel.color = Color.green;
                    } else {
                        value = ENV.DisabledSpeed.Value;

                        UIManager.SpeedPanel.SpeedLabel.color = Color.red;
                    }
                }

                UIManager.SpeedPanel.SpeedLabel.text = string.Format("{0}x", (float)Math.Round(value, ENV.RoundDigits.Value));
            } catch (Exception e) { Log.Fatal(e); }

            return true; // Continue with the original setter method
        }
    }
}
