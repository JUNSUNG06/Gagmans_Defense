using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Collections;
using UnityEngine;

public class UnitView : MonoBehaviour
{
    public SPUM_SpriteList mySpriteList;

    public void SetImage(UnitController target)
    {
        SPUM_SpriteList _target = target.Equipment.spriteList;

        for (int i = 0; i < mySpriteList._itemList.Count; i++)
            mySpriteList._itemList[i].sprite = _target._itemList[i].sprite;
        for (int i = 0; i < mySpriteList._eyeList.Count; i++)
            mySpriteList._eyeList[i].sprite = _target._eyeList[i].sprite;
        for (int i = 0; i < mySpriteList._hairList.Count; i++)
            mySpriteList._hairList[i].sprite = _target._hairList[i].sprite;
        for (int i = 0; i < mySpriteList._bodyList.Count; i++)
            mySpriteList._bodyList[i].sprite = _target._bodyList[i].sprite;
        for (int i = 0; i < mySpriteList._clothList.Count; i++)
            mySpriteList._clothList[i].sprite = _target._clothList[i].sprite;
        for (int i = 0; i < mySpriteList._armorList.Count; i++)
            mySpriteList._armorList[i].sprite = _target._armorList[i].sprite;
        for (int i = 0; i < mySpriteList._pantList.Count; i++)
            mySpriteList._pantList[i].sprite = _target._pantList[i].sprite;
        for (int i = 0; i < mySpriteList._weaponList.Count; i++)
            mySpriteList._weaponList[i].sprite = _target._weaponList[i].sprite;
        for (int i = 0; i < mySpriteList._backList.Count; i++)
            mySpriteList._backList[i].sprite = _target._backList[i].sprite;
    }
}
