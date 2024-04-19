using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
  


public bool killedAllowed = true;
public bool guestKilled = false;


public TextMeshProUGUI rentText;
public TextMeshProUGUI moneyText;
public TextMeshProUGUI killsText;


public GameObject MANAGER;


// if kill the guest show() kill count

    private void Start()
    {
        
        // Get reference to the Text component
       // moneyText = GetComponent<TextMeshProUGUI>();
        MANAGER = GameObject.Find("MANAGER");

        int rent = MANAGER.GetComponent<StateVariables>().rent;
        rentText.text = "rent: " + rent;

        int money = MANAGER.GetComponent<StateVariables>().money;
        moneyText.text = "money: " + money;

        int kills = MANAGER.GetComponent<StateVariables>().kills;
        killsText.text = kills.ToString();


    }

    // private void Update()
    // {

            
    // }


public void GetMoney(){

    //hasAccepted = true;
    int money = MANAGER.GetComponent<StateVariables>().money;
    money += 10;
     MANAGER.GetComponent<StateVariables>().money = money;

     
     moneyText.text = "money: " + money;
    Debug.Log(money);
}

public void AcceptGuest(){

    int money = MANAGER.GetComponent<StateVariables>().money;
    int rent = MANAGER.GetComponent<StateVariables>().rent;
        money += rent;
    MANAGER.GetComponent<StateVariables>().money = money;
    moneyText.text = "money: " + money;

    MANAGER.GetComponent<ChangeScenes>().setHasAccepted(); 

    // load another scene instead o room scene 
    Debug.Log("offer accepted");

}

public void KillGuest(){
 int money = MANAGER.GetComponent<StateVariables>().money;
  int kills = MANAGER.GetComponent<StateVariables>().kills;  
    
     if (MANAGER.GetComponent<ChangeScenes>().getAccepted() == true && killedAllowed == true) {

Debug.Log("are you here");

   
              money += 50;
    MANAGER.GetComponent<StateVariables>().money = money;
    moneyText.text = "money: " + money;



    kills += 1;
    MANAGER.GetComponent<StateVariables>().kills = kills;
    killsText.text = kills.ToString();


       

            killedAllowed = false; 
    }

    
  


 // MANAGER.GetComponent<ChangeScenes>().setGuestKilled(); 
    //MANAGER.GetComponent<ChangeScenes>().GoToRoom();
   // guestKilled = true;
    Debug.Log("guest is killed");
    Debug.Log(money);

}



public bool TrySpendMoney(int spendMoney) {

    int money = MANAGER.GetComponent<StateVariables>().money;
    if (money >= spendMoney){
        money -= spendMoney;
   // MANAGER.GetComponent<StateVariables>().money = money;

       MANAGER.GetComponent<StateVariables>().money = money;
         moneyText.text = "money: " + money;
        //OnMoneyCharged?.Invoke(this, EventArgs.Empty); 
        return true; // can afford


    } else{

    
    return false; // cant affort

    }


}

public void CalculateRent(int newRent){
int rent = MANAGER.GetComponent<StateVariables>().rent;
rent += newRent;
MANAGER.GetComponent<StateVariables>().rent = rent;


 Debug.Log(rent );

 rentText.text = "rent: " + rent;
     

}






}




