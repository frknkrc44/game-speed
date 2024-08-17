using BepInEx.Configuration;
// using BepInEx.Unity.IL2CPP.UnityEngine;
using UnityEngine;
using Utils.Settings;

namespace GameSpeed.Settings;

public static class ENV {
    // Mission_General
    private readonly static string settings = "0.⚙️ Settings";
    public static ConfigElement<bool> Enabled { get; set; }
    public static ConfigElement<float> Modifier { get; set; }
    public static ConfigElement<float> IncreaseDecreaseRate { get; set; }
    public static ConfigElement<int> RoundDigits { get; set; }
    public static ConfigElement<KeyCode> EnableDisableKey { get; set; }
    public static ConfigElement<KeyCode> IncreaseSpeedKey { get; set; }
    public static ConfigElement<KeyCode> DecreaseSpeedKey { get; set; }


    public static class Settings {

        public static void Setup() {
            Utils.Settings.Config.AddConfigActions(Load);
        }

        // Load the plugin config variables.
        private static void Load() {
            Enabled = Utils.Settings.Config.Bind(
                settings,
                nameof(Enabled),
                true,
                "Start the game with the speed modifier enabled/disabled"
            );

            Modifier = Utils.Settings.Config.Bind(
                settings,
                nameof(Modifier),
                2F,
                "Define the game speed multiplier. e.g. (1 * modifier) during the game (0 * modifier) on paused screen"
            );

            IncreaseDecreaseRate = Utils.Settings.Config.Bind(
                settings,
                nameof(IncreaseDecreaseRate),
                0.1F,
                "Define the speed increase/decrease rate"
            );

            RoundDigits = Utils.Settings.Config.Bind(
               settings,
               nameof(RoundDigits),
               1,
               "Used to round the game speed when increased/decreased"
           );

            EnableDisableKey = Utils.Settings.Config.Bind(
                settings,
                nameof(EnableDisableKey),
                KeyCode.F9,
                "Enable/Disable the speed modifier"
            );

            IncreaseSpeedKey = Utils.Settings.Config.Bind(
                settings,
                nameof(IncreaseSpeedKey),
                KeyCode.Equals,
                "Increase the game speed based on the " + nameof(IncreaseDecreaseRate) + " value"
            );

            DecreaseSpeedKey = Utils.Settings.Config.Bind(
                settings,
                nameof(DecreaseSpeedKey),
                KeyCode.Minus,
                "Decrease the game speed based on the " + nameof(IncreaseDecreaseRate) + " value"
            );

            Utils.Settings.Config.Save();
        }
    }
}
