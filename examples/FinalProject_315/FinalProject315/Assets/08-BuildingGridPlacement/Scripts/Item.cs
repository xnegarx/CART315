using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item 




{


public enum ItemType{
    Chair,
    Table,
    Bed
}

public static int GetCost(ItemType itemType) { 
    switch (itemType) {


    default:
    case ItemType.Chair: return 0;
    case ItemType.Table: return 30;
    case ItemType.Bed: return 100;
}
}


public static int UpRent(ItemType itemType) { 
    switch (itemType) {


    default:
    case ItemType.Chair: return 20;
    case ItemType.Table: return 30;
    case ItemType.Bed: return 40;
}
}



public static Sprite GetSprite(ItemType itemType) {
     switch (itemType) {
        default:
        case ItemType.Chair: return GameAssets.Instance.Chair;
        case ItemType.Table: return GameAssets.Instance.Table;
        case ItemType.Bed: return GameAssets.Instance.Bed;

     }

}













}
