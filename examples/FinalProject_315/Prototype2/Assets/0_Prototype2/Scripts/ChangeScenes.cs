using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScenes : MonoBehaviour
{

//public Player player;



public static ChangeScenes instance;
private bool hasAccepted = false;






private void Awake(){
    if (instance == null)
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    } 
    // else
    // {
    //     Destroy(gameObject);
    // }
}

void Start(){
    	
   
    
}


	

 public void setHasAccepted ()
{
    hasAccepted = true;
}


bool getAccepted(){
    Debug.Log(hasAccepted);
    return hasAccepted;
}




public void GoToCounter(){
    SceneManager.LoadScene("Reception");
   

}

public void GoToRoom(){
    Debug.Log(getAccepted());
      if (getAccepted() == true){
        SceneManager.LoadScene("RoomLocked");
      //  Invoke(SceneManager.LoadScene("Room"), 10f);
    } else {
    SceneManager.LoadScene("Room");
    }

}

// will add a new introductery scene afterwards
public void StartGame(){
    SceneManager.LoadScene("Story");

}





}
