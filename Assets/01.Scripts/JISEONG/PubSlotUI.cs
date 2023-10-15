using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UIElements;

public class PubSlotUI : VisualElement
{
    private const string styleResource = "slot";
    public new class UxmlFactory : UxmlFactory<PubSlotUI> { }

    private Button button;
    private VisualElement image;
    private VisualElement root;
    private ProgressBar timer;

    public PubSlotUI()
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

        timer = new ProgressBar();
        timer.name = "timer";
        timer.AddToClassList("s_timer");
        root.Add(timer);
    }
    public void Setting(Action action)
    {
        button.RegisterCallback<ClickEvent>(e => action?.Invoke());
    }
    public void SettingTimerText(int time)
    {
        timer.title = $"{time / 60}:{time % 60}";
    }
    public void SettingProgressBar(float percent)
    {
        timer.value = percent;
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