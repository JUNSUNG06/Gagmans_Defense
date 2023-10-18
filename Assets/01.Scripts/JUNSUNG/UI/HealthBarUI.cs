using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.PlayerSettings;

public class HealthBarUI : VisualElement
{
    private const string styleResource = "HealthBar";
    public new class UxmlFactory : UxmlFactory<HealthBarUI> { }

    private VisualElement root;
    private VisualElement background;
    private VisualElement bar;

    public HealthBarUI()
    {
        styleSheets.Add(Resources.Load<StyleSheet>($"StyleSheets/{styleResource}"));

        root = new VisualElement();
        root.name = "root";
        root.AddToClassList("root");
        hierarchy.Add(root);

        background = new VisualElement();
        background.name = "background";
        root.Add(background);

        bar = new VisualElement();
        bar.name = "bar";
        background.Add(bar);

        //Hide();
    }

    public void Show()
    {
        root.AddToClassList("show");
    }

    public void Hide()
    {
        root.AddToClassList("hide");
    }

    public void SetBar(float percent)
    {
        percent = Mathf.Clamp(percent, 0, 1);
        percent *= 100;
        bar.style.width = Length.Percent(percent);
    }

    public void SetPosition(Vector2 pos)
    {
        root.style.left = new Length(pos.x - root.layout.width / 2, LengthUnit.Pixel);
        root.style.top = new Length(pos.y, LengthUnit.Pixel);
    }
}
