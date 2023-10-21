using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public enum CompareSign
{
    Greater, 
    Less,
    Equals,
}


public class SideLabel : VisualElement
{
    private const string styleResource = "SideLabel";

    public new class UxmlFactory : UxmlFactory<SideLabel> { }

    private VisualElement container;
    private Label right;
    private VisualElement left;
    private Label left_text;
    private Label left_sign;

    public SideLabel()
    {
        styleSheets.Add(Resources.Load<StyleSheet>($"StyleSheets/{styleResource}"));

        container = new VisualElement();
        container.name = "container";
        container.AddToClassList("container");
        hierarchy.Add(container);

        right = new Label();
        right.name = "right";
        right.AddToClassList("text");
        container.Add(right);

        left = new VisualElement();
        left.name = "left";
        left.AddToClassList("left");
        container.Add(left);

        left_text = new Label();
        left_text.name = "text";
        left_text.AddToClassList("text");
        left.Add(left_text);

        left_sign = new Label();
        left_sign.name = "sign";
        left_sign.AddToClassList("text");
        left.Add(left_sign);
    }

    public void SetLeftText(string str, CompareSign _sign)
    {
        left_text.text = str;

        left_sign.RemoveFromClassList("blue");
        left_sign.RemoveFromClassList("red");
        left_sign.RemoveFromClassList("gray");

        string style;
        string sign;

        if(_sign == CompareSign.Greater)
        {
            style = "red";
            sign = "+";
        }
        else if(_sign == CompareSign.Less)
        {
            style = "blue";
            sign = "-";
        }
        else
        {
            style = "gray";
            sign = "=";
        }

        left_text.AddToClassList(style);
        left_sign.text = sign;
    }

    public void SetRightText(string str)
    {
        right.text = str;
    }
}
