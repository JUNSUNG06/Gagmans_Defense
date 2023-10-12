using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class VerticalProgressBar : VisualElement
{
    public new class UxmlFactory : UxmlFactory<VerticalProgressBar, UxmlTraits> { }
    public new class UxmlTraits : VisualElement.UxmlTraits
    {
        UxmlFloatAttributeDescription percent = new UxmlFloatAttributeDescription { name = "percent", defaultValue = 0 };

        public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
        {
            base.Init(ve, bag, cc);
            var ate = ve as VerticalProgressBar;

            ate.Percent = percent.GetValueFromBag(bag, cc);
        }
    }

    public float Percent { get; set; }

    private VisualElement progressBar;
    private VisualElement background;
    private VisualElement percentBar;

    public VerticalProgressBar()
    {
        styleSheets.Add(Resources.Load<StyleSheet>("StyleSheets/progressBar"));

        progressBar = new VisualElement();
        progressBar.name = "ProgressBar";
        hierarchy.Add(progressBar);

        background = new VisualElement();
        background.name = "Background";
        progressBar.Add(background);

        percentBar = new VisualElement();
        percentBar.name = "Percent";
        background.Add(percentBar);
    }

    public void SetPercent(float value)
    {
        Percent = Mathf.Clamp(value, 0, 100);
        percentBar.style.height = Length.Percent(Percent);
    }
}
