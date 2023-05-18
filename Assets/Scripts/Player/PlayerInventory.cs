using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public GameObject gameController;
    private Inventory inventory;
    [SerializeField] private UI_Inventory uiInventory;
 
    void Awake()
    {
        inventory = new Inventory();
        uiInventory.SetInventory(inventory);

        ItemWorld.SpawnItemWorld(new Vector3(4, -1), new Item {itemType = Item.ItemType.Armor, amount = 1});
        ItemWorld.SpawnItemWorld(new Vector3(4, -2), new Item {itemType = Item.ItemType.ArmorAlt, amount = 1});
        ItemWorld.SpawnItemWorld(new Vector3(4, -4), new Item {itemType = Item.ItemType.Hairpin, amount = 1});
        ItemWorld.SpawnItemWorld(new Vector3(4, -57), new Item {itemType = Item.ItemType.HairpinAlt, amount = 1});
        ItemWorld.SpawnItemWorld(new Vector3(4, -61), new Item {itemType = Item.ItemType.Bow, amount = 1});
        ItemWorld.SpawnItemWorld(new Vector3(4, -64), new Item {itemType = Item.ItemType.BowAlt, amount = 1});
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        ItemWorld itemWorld = collider.GetComponent<ItemWorld>();
        if (itemWorld != null)
        {
            //touching item
            inventory.AddItem(itemWorld.GetItem());
            itemWorld.DestroySelf();
            gameController.GetComponent<WinConditions>().artifactNum ++;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
