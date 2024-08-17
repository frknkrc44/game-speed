using System;
using GameSpeed.Settings;
using UnityEngine;
using UniverseLib.Input;

namespace GameSpeed.Systems;

public class KeyBindsBehaviour : MonoBehaviour {
    public KeyBindsBehaviour(IntPtr handle) : base(handle) { }

    private long threshold = 100;

    public void Start() {
        ENV.Enabled.OnValueChanged.Add((value) => {
            Time.timeScale = Hooks.TimePatch.originalTimeScale;
            Utils.Logger.Log.Trace(value);
        });
        ENV.Modifier.OnValueChanged.Add((value) => {
            Time.timeScale = Hooks.TimePatch.originalTimeScale;
            Utils.Logger.Log.Trace(value);
        });
    }

    public void Update() {
        if (InputManager.GetKeyDown(ENV.EnableDisableKey.Value)) {
            ENV.Enabled.Value = !ENV.Enabled.Value;
        }

        if (InputManager.GetKey(ENV.IncreaseSpeedKey.Value) &&
            !Utils.Database.Cache.IsBlocked(nameof(ENV.IncreaseSpeedKey), threshold)) {
            ENV.Modifier.Value = (float)Math.Round(ENV.Modifier.Value + ENV.IncreaseDecreaseRate.Value, ENV.RoundDigits.Value);
        }

        if (InputManager.GetKey(ENV.DecreaseSpeedKey.Value) &&
            !Utils.Database.Cache.IsBlocked(nameof(ENV.DecreaseSpeedKey), threshold)) {
            ENV.Modifier.Value = (float)Math.Round(ENV.Modifier.Value - ENV.IncreaseDecreaseRate.Value, ENV.RoundDigits.Value);
        }
    }
}
