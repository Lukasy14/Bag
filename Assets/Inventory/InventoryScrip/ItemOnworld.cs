using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOnworld : MonoBehaviour
{
    public Item thisItem;
    public Inventory playerInventory;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("2");
            AddNewItem();
            Destroy(gameObject);
        }
    }

    public void AddNewItem()
    {
        if(!playerInventory.itemList.Contains(thisItem))
        { 
            Debug.Log("1");
            playerInventory.itemList.Add(thisItem);
        }
        else
        {
            thisItem.itemHeld += 1;
        }

        InventorManager.RefreshItem();
    }
}
