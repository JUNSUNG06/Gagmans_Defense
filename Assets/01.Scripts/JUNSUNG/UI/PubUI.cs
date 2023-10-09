using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class PubUI : GameUI
{
    public List<PubSlotUI> slotList;
    public PubUI(TemplateContainer container) : base(container)
    {
        container.name = "pub";
        var visualElements = root.Query("PubSlotUI").ToList();
        slotList = visualElements.Select(ve => ve as PubSlotUI).Where(ve => ve != null).ToList();
    }
}
