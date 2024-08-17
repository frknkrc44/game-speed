using UnityEngine;
using UnityEngine.UI;
using UniverseLib.UI;

namespace GameSpeed.UI.Panels;

public class SpeedPanel {
    public static SpeedPanel Instance { get; private set; }

    public Text SpeedLabel { get; set; }
    public static RectTransform NavBarRect;

    public SpeedPanel() : base() {
        Instance = this;

        GameObject navbarPanel = UIFactory.CreateUIObject("MainNavbar", UIManager.UIRoot);
        UIFactory.SetLayoutGroup<HorizontalLayoutGroup>(navbarPanel, false, false, true, true, 5, 4, 4, 4, 4, TextAnchor.MiddleCenter);
        navbarPanel.AddComponent<Image>().color = new Color(0.1f, 0.1f, 0.1f);
        NavBarRect = navbarPanel.GetComponent<RectTransform>();
        NavBarRect.pivot = new Vector2(0.5f, 1f);

        SetNavBarAnchor();

        SpeedLabel = UIFactory.CreateLabel(navbarPanel, "SpeedLabel", "100x");
        UIFactory.SetLayoutElement(SpeedLabel.gameObject, minWidth: 50, minHeight: 60, flexibleHeight: 0, preferredHeight: 60, flexibleWidth: 0, preferredWidth: 50);

        navbarPanel.SetActive(true);
    }

    public static void SetNavBarAnchor() {
        NavBarRect.anchorMin = new Vector2(0.5f, 1f);
        NavBarRect.anchorMax = new Vector2(0.5f, 1f);
        NavBarRect.anchoredPosition = new Vector2(NavBarRect.anchoredPosition.x, 0);
        NavBarRect.sizeDelta = new(0f, 35f);
    }
}
