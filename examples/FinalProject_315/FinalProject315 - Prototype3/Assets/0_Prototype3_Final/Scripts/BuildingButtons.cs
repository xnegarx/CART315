using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingButtons : MonoBehaviour
{

  // void Start()
  //   {
       
  //     Hide();

  //   }



    // Start is called before the first frame update
  public void Show() {
   // this.ShopCostumer = ShopCostumer;
    gameObject.SetActive(true);

    Debug.Log("offer made");
  }
  // hide shop?
  public void Hide(){
    gameObject.SetActive(false); 
  }
}
