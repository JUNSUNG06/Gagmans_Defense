using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class GameUI
{
    public TemplateContainer container;
    protected VisualElement root;

    public GameUI(TemplateContainer _container)
    {
        container = _container;
        root = container.Q("window");
        Button closeBtn = root.Q<Button>("closeBtn");
        
        if(closeBtn != null)
        {
            closeBtn.RegisterCallback<ClickEvent>(e =>
            {
                Hide();
            });
        }
    }

    public virtual void Show() 
    {
        container.style.display = DisplayStyle.Flex;
        container.BringToFront();
        UIManager.Instance.CurrentUI = this;
        UIManager.Instance.OpendUI.Add(this);
    }

    public virtual void Hide() 
    {
        container.style.display = DisplayStyle.None;
        UIManager.Instance.OpendUI.Remove(this);
    }
}
