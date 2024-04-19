
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using CodeMonkey.Utils;

public class UI_Shop : MonoBehaviour
{

private Transform Container;
private Transform ShopItem;

public Player player;

public Inventory inventory;


//bool TrySpendMoney(int money);
//if true, have enough money
//if false, dont have enough money



private void Awake(){
    Container = transform.Find("Container");
    ShopItem = Container.Find("ShopItem");
    ShopItem.gameObject.SetActive(false);

    
}



private void Start(){

    Debug.Log("chishod");


   CreateItemButton(Item.ItemType.Chair, Item.GetSprite(Item.ItemType.Chair), "Chair", "upgrade rent +20", Item.GetCost(Item.ItemType.Chair), 0);
       
   CreateItemButton(Item.ItemType.Table, Item.GetSprite(Item.ItemType.Table), "Table", "upgrade rent +30", Item.GetCost(Item.ItemType.Table), 1);
   CreateItemButton(Item.ItemType.Bed, Item.GetSprite(Item.ItemType.Bed), "Bed", "upgrade rent +40", Item.GetCost(Item.ItemType.Bed), 2);

 Hide();
}


private void CreateItemButton(Item.ItemType itemType, Sprite itemSprite, string itemName, string itemInfo, int itemCost, int positionIndex) {

Transform shopItemTransform = Instantiate(ShopItem, Container);

RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>();
float shopItemWidth = 210f;
 shopItemRectTransform.anchoredPosition = new Vector2(shopItemWidth*positionIndex, 0); 

shopItemTransform.Find("name").GetComponent<TextMeshProUGUI>().SetText(itemName);

 shopItemTransform.Find("Info").GetComponent<TextMeshProUGUI>().SetText(itemInfo);



 shopItemTransform.Find("price").GetComponent<TextMeshProUGUI>().SetText(itemCost.ToString());


shopItemTransform.Find("itemImage").GetComponent<Image>().sprite = itemSprite;

 shopItemTransform.gameObject.SetActive(true);

shopItemTransform.GetComponent<Button_UI>().ClickFunc = () => {

 
  // clicked on shop item button
  TryBuyItem(itemType);

  };

}


  // show shop? 
  public void Show() {
   // this.ShopCostumer = ShopCostumer;
    gameObject.SetActive(true);
  }
  // hide shop?
  public void Hide(){
    gameObject.SetActive(false); 
  }



// this function is called when we click on item shop
private void TryBuyItem(Item.ItemType itemType) {

if (player.TrySpendMoney(Item.GetCost(itemType))) {
  Debug.Log("Bought item: " + itemType); // can afford
  // take this to inventory
  // count how many chairs/tables/beds
  // that how many prefabs we will load
  // game objects save on load
  inventory.AddToInventory(itemType);
 
  player.CalculateRent(Item.UpRent(itemType));

  Debug.Log("New rent:" + Item.UpRent(itemType));

}
 





}





}
