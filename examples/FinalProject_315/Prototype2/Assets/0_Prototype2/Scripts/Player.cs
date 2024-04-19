using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
  
 //[SerializeField] TextMeshProUGUI moneyText

//public event EventHandler OnMoneyCharged;

private int money = 0;
private int rent = 0;

public bool hasAccepted = false;

public TextMeshProUGUI rentText;
public TextMeshProUGUI moneyText;

public GameObject MANAGER;




    private void Start()
    {
        // Get reference to the Text component
       // moneyText = GetComponent<TextMeshProUGUI>();
        Debug.Log(moneyText);
        Debug.Log(rentText);
        MANAGER = GameObject.Find("MANAGER");

    }

    // private void Update()
    // {

            
    // }


public void GetMoney(){
    money += 10;
    moneyText.text = "money: " + money;
        
    Debug.Log(money);
}

public void AcceptGuest(){
    money = rent;
    moneyText.text = "money: " + money;
    MANAGER.GetComponent<ChangeScenes>().setHasAccepted();
    // load another scene instead o room scene 
    Debug.Log("offer accepted");

}



public bool TrySpendMoney(int spendMoney) {
    if (money >= spendMoney){
        money -= spendMoney;
     moneyText.text = "money: " + money;
     
     CalculateRent(rent);
        //OnMoneyCharged?.Invoke(this, EventArgs.Empty); 
        return true; // can afford


    } else{

    
    return false; // cant affort

    }


}

public void CalculateRent(int newRent){

rent += newRent;

 Debug.Log(rent + newRent);

 rentText.text = "rent: " + rent;
     

}






}




