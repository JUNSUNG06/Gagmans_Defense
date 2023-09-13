using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="SO/ItemSO")]
public class ItemSO : ScriptableObject
{
    public string itemmName;
    public Sprite image;
    public ItemType type;
}
