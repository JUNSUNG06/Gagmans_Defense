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
        slotList = root.Query<PubSlotUI>("PubSlotUI").ToList();
        Debug.Log(slotList.Count);
    }
}
