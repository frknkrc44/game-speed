using BepInEx.Configuration;

namespace PluginName.Settings;

public static class ENV {
    // Mission_General
    private readonly static string example = "0.🧪 Example";
    public static ConfigEntry<float> Example;


    public static class Testing {

        public static void Setup() {
            Utils.Settings.Config.AddConfigActions(load);
        }

        // Load the plugin config variables.
        private static void load() {
            // Mission_General
            Example = Utils.Settings.Config.Bind(
                example,
                nameof(Example),
                2F,
                "Just an example value :)"
            );

            Utils.Settings.Config.Save();
        }
    }
}
