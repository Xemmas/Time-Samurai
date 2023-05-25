using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Item 
{
    public enum ItemType 
    {
        Armor,
        ArmorAlt,
        Bow,
        BowAlt,
        Hairpin,
        HairpinAlt,
    }

    public ItemType itemType;
    public int amount;

    public Sprite GetSprite()
    {
        switch(itemType)
        {
            default: 
            case ItemType.Armor: return ItemAssets.Instance.armorSprite;
            case ItemType.ArmorAlt: return ItemAssets.Instance.armorAltSprite;
            case ItemType.Bow: return ItemAssets.Instance.bowSprite;
            case ItemType.BowAlt: return ItemAssets.Instance.bowAltSprite;
            case ItemType.Hairpin: return ItemAssets.Instance.hairpinSprite;
            case ItemType.HairpinAlt: return ItemAssets.Instance.hairpinAltSprite;
        }
    }
    
}
