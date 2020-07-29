using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOnworld : MonoBehaviour
{
    public Item thisItem;
    public Inventory playerInventory;
    public Slot slot;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            AddNewItem();
            Destroy(gameObject);
        }
    }

    public void AddNewItem()
    {
        if(!playerInventory.itemList.Contains(thisItem))
        { 
            for(int i = 0; i < playerInventory.itemList.Count; i++)
            {
                if(playerInventory.itemList[i] == null)
                {
                    playerInventory.itemList[i] = thisItem;
                    break;
                }
            }
        }
        else
        {
            thisItem.itemHeld += 1;
        }

        InventorManager.RefreshItem();
    }
}
