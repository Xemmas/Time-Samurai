using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private List<Item> itemList;
    public event EventHandler OnItemListChanged;

    public Inventory()
    {
        itemList = new List<Item>();
        //AddItem(new Item {itemType = Item.ItemType.ArmorAlt, amount = 1});
        //AddItem(new Item {itemType = Item.ItemType.Bow, amount = 1});


    }

    public void AddItem(Item item)
    {
        itemList.Add(item);
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public List<Item> GetItemList()
    {
        return itemList;
    }
}
