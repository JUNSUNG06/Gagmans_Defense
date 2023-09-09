using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="SO/ItemSO")]
public class ItemSO : ScriptableObject
{
    public string equipName;
    public Sprite sprite;
    public ItemType itempType;
}
