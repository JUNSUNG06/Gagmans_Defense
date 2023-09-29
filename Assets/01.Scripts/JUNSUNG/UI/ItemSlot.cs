using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ItemSlot : VisualElement
{
    #region Uxml
    [UnityEngine.Scripting.Preserve]
    public new class UxmlFactory : UxmlFactory<ItemSlot, UxmlTraits> {}
    #endregion
    private const string styleResource = "ItemSlotStyle";

    private VisualElement baseElem;
    private VisualElement image;
    private Item item;

    public Item MyItem
    {
        get { return item; }
        set
        {
            item = value;
            image.style.backgroundImage = new StyleBackground(item.Info.image);
        }
    }

    public ItemSlot()
    {
        styleSheets.Add(Resources.Load<StyleSheet>($"StyleSheets/{styleResource}"));

        baseElem = new VisualElement();
        hierarchy.Add(baseElem);
        baseElem.AddToClassList("i_slot");

        image = new VisualElement();
        baseElem.Add(image);
    }
}
