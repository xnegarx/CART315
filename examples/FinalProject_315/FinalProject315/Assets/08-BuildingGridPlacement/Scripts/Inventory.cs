using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    
    

   // List<Item.ItemType> inventoryList = new List<Item.ItemType>();
   private Dictionary<Item.ItemType, int> inventoryList = new Dictionary<Item.ItemType, int>();

    
    

      public bool HasItemType(Item.ItemType itemType) {
        return inventoryList.ContainsKey(itemType) && inventoryList[itemType] > 0;
    }



    public bool RemoveFromInventory(Item.ItemType itemType){
         int inventorySum =  inventoryList[itemType];
        if(inventorySum ==0) return false;
           
           inventorySum-=1;
           //  inventoryList.Add(itemType, inventorySum);
            inventoryList[itemType] = inventorySum;
             Debug.Log(inventoryList[itemType]);
             return true;

    }

    public void AddToInventory(Item.ItemType itemType){

    //inventoryList.Add(itemType);

       // Debug.Log(inventoryList[0]);

       //if (inventoryList.TryGetValue(Item.ItemType itemType, out value))
       if (inventoryList.ContainsKey(itemType))
        {
            Debug.Log("Fetched value:");
           
           int inventorySum =  inventoryList[itemType];
           inventorySum+=1;
           //  inventoryList.Add(itemType, inventorySum);
            inventoryList[itemType] = inventorySum;
             Debug.Log(inventoryList[itemType]);



        }
        else{
            inventoryList.Add(itemType, 1);
            Debug.Log(inventoryList[itemType]);

      

        }


    }
}
