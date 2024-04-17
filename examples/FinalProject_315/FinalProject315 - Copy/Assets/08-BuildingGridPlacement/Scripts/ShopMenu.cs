using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopMenu : MonoBehaviour
{

    [SerializeField] public UI_Shop uiShop;
    [SerializeField] public BuildingButtons buildingButtons;

    private bool shopClicked = false;
    private bool inventoryClicked = false;
   
   
   public void ShowShopMenu(){



  if(shopClicked == false ){
        buildingButtons.Hide();
     uiShop.Show(); 
 
     shopClicked = true;
      Debug.Log("hellow");


   } else  {
    uiShop.Hide();

    shopClicked = false;
   }
   

   } 


   public void ShowInventoryMenu(){


if(inventoryClicked == false ){
      uiShop.Hide();
     buildingButtons.Show(); 
   
     inventoryClicked = true;
      Debug.Log("hellow");


   } else {
    
    buildingButtons.Hide();
    inventoryClicked = false;
   }



   }




}