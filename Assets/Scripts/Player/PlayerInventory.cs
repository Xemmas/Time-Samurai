using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private UI_Inventory uiInventory;
    private Inventory inventory;

    void Awake()
    {
        inventory = new Inventory();
        uiInventory.SetInventory(inventory);

        ItemWorld.SpawnItemWorld(new Vector3(0, 0), new Item {itemType = Item.ItemType.Armor, amount = 1});
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        ItemWorld itemWorld = collider.GetComponent<ItemWorld>();
        if(itemWorld != null)
        {
            //touching item
            inventory.AddItem(itemWorld.GetItem());
            itemWorld.DestroySelf();
        }
    }


    
}
