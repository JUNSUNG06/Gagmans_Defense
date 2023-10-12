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

    public ItemSlot()
    {
        styleSheets.Add(Resources.Load<StyleSheet>($"StyleSheets/{styleResource}"));

        baseElem = new VisualElement();
        hierarchy.Add(baseElem);
        baseElem.AddToClassList("i_slot");

        image = new VisualElement();
        image.name = "image";
        baseElem.Add(image);
    }

    public void SetImage(Sprite _image)
    {
        image.style.backgroundImage = new StyleBackground(_image);
    }

    public void SetItem(Item _item)
    {
        item = _item;

        if(item != null)
            image.style.backgroundImage = new StyleBackground(item.Info.image);
        else
            image.style.backgroundImage = null;
    }

    public Item GetItem()
    {
        return item;
    }
}
