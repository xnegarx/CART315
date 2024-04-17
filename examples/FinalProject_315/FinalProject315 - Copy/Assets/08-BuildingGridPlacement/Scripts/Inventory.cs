using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    private Dictionary<Item.ItemType, int> inventoryList = new Dictionary<Item.ItemType, int>();

   
    public bool HasItemType(Item.ItemType itemType) {
        return inventoryList.ContainsKey(itemType) && inventoryList[itemType] > 0;
    }


    public bool RemoveFromInventory(Item.ItemType itemType){
        int inventorySum =  inventoryList[itemType];
        if(inventorySum ==0) return false;   
        inventorySum-=1;
        inventoryList[itemType] = inventorySum;
        Debug.Log(inventoryList[itemType]);
        return true;
    }

    public void AddToInventory(Item.ItemType itemType){

       if (inventoryList.ContainsKey(itemType))
        {
            int inventorySum = inventoryList[itemType];
            inventorySum+=1;
            inventoryList[itemType] = inventorySum;
            Debug.Log(inventoryList[itemType]);
        }
        else{
            inventoryList.Add(itemType, 1);
            Debug.Log(inventoryList[itemType]);
        }
    }
}
