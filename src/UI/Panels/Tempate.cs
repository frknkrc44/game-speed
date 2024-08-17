using UnityEngine;
using UniverseLib.UI;

namespace GameSpeed.UI.Panels;

public class TemplatePanel : UniverseLib.UI.Panels.PanelBase {
    public static TemplatePanel Instance { get; private set; }
    public override string Name => "Template Panel";
    public override int MinWidth => 10;
    public override int MinHeight => 10;
    public override Vector2 DefaultAnchorMin => new Vector2(0.5f, 1f);
    public override Vector2 DefaultAnchorMax => new Vector2(0.5f, 1f);
    public override Vector2 DefaultPosition => new Vector2(0 - MinWidth / 2, Screen.height);
    public override bool CanDragAndResize => false;

    public TemplatePanel(UIBase owner) : base(owner) {
        Instance = this;
    }

    protected override void ConstructPanelContent() { }

}
