using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class GameUI
{
    protected TemplateContainer container;
    protected VisualElement root;

    public GameUI(TemplateContainer _container)
    {
        container = _container;
        root = container.Q("window");
    }

    public virtual void Show() 
    {
        container.style.display = DisplayStyle.Flex;
    }

    public virtual void Hide() 
    {
        container.style.display = DisplayStyle.None;
    }
}
