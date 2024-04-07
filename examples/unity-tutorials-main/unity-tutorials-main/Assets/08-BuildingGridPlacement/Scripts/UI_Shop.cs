using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Shop : MonoBehaviour
{

private Transform Container;
private Transform ShopItem;

private void Awake(){
    Container = transform.Find("Container");
    ShopItem = Container.Find("ShopItem");
    ShopItem.gameObject.SetActive(false);
    
}



private void Start(){
    Debug.Log("Start");
    CreateItemButton(Item.GetSprite(Item.ItemType.Chair), "Chair", "upgrade rent to 20", Item.GetCost(Item.ItemType.Chair), 0);
    CreateItemButton(Item.GetSprite(Item.ItemType.Table), "Chair", "upgrade rent to 30", Item.GetCost(Item.ItemType.Table), 1);
    // CreateItemButton(Item.GetSprite(Item.ItemType.Bed), "Bed", "upgrade rent to 40", Item.GetCost(Item.ItemType.Bed), 0);


}


private void CreateItemButton(Sprite itemSprite, string itemName, string itemInfo, int itemCost, int positionIndex) {


Transform shopItemTransform = Instantiate(ShopItem, Container);

RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>();
float shopItemHeight = 30f;
shopItemRectTransform.anchoredPosition = new Vector2(0, -shopItemHeight*positionIndex); 

shopItemTransform.Find("name").GetComponent<TextMeshProUGUI>().SetText(itemName);

shopItemTransform.Find("info").GetComponent<TextMeshProUGUI>().SetText(itemInfo);

shopItemTransform.Find("price").GetComponent<TextMeshProUGUI>().SetText(itemCost.ToString());


shopItemTransform.Find("itemImage").GetComponent<Image>().sprite = itemSprite;











}








}
