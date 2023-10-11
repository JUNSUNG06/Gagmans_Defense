using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UIElements;

public class TrainingSlotUI : VisualElement
{
    private const string styleResource = "slot";
    public new class UxmlFactory : UxmlFactory<TrainingSlotUI> { }

    private Button button;
    private VisualElement image;
    private VisualElement root;

    public TrainingSlotUI()
    {
        styleSheets.Add(Resources.Load<StyleSheet>($"StyleSheets/{styleResource}"));

        root = new VisualElement();
        root.name = "root";
        root.AddToClassList("s_root");
        hierarchy.Add(root);

        VisualElement visual = new VisualElement();
        visual.name = "visual";
        visual.AddToClassList("s_visual");
        root.Add(visual);

        image = new VisualElement();
        image.name = "image";
        visual.Add(image);

        button = new Button();
        button.name = "buyBtn";
        button.AddToClassList("s_btn");
        root.Add(button);
    }

    public void SettingBtn(int cost)
    {
        button.text = cost.ToString();
    }

    public void SettingImage(Sprite img)
    {
        image.style.backgroundImage = new StyleBackground(img);
    }
}