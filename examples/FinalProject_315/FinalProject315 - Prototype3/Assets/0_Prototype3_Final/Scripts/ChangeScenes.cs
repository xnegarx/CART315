using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScenes : MonoBehaviour
{
    public static ChangeScenes instance;
  public bool hasAccepted = false;
    private bool guestKilled = false;

    bool roomButton = false;
    bool roomButton2 = false;
    bool roomButtonStory = false;
    bool receptionButton = false;
    bool receptionButton2 =false;
    bool killButton = false;

    //bool skip= false;

    private void Awake(){
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } 
    }

    void Start(){
        hasAccepted = false;
    }

    void Update(){

        /*** reset booleans ***/
        // i have to reset the booleans everytime, since im reassigning my buttons based on the circumstances
        if(SceneManager.GetActiveScene().name.Equals("Reception") ){
            receptionButton =false;  
            receptionButton2=false;
            killButton =false;
        }

        if(SceneManager.GetActiveScene().name.Equals("Room") || SceneManager.GetActiveScene().name.Equals("RoomLocked")){
            roomButton =false;
            roomButton2 =false;
        }



        // if in "Story" scene and no room button, assign the button (goes to room)
        if(!roomButtonStory && SceneManager.GetActiveScene().name.Equals("Story") ){
            Button test =  GameObject.Find("ButtonRoom").GetComponent<Button>();
            test.onClick.AddListener(GoToRoom);
            roomButtonStory=true;
        }

        // if in "Room" scene and no reception button, assign the button (goes to reception)
        if(!receptionButton && SceneManager.GetActiveScene().name.Equals("Room") ){
            Button test =  GameObject.Find("ButtonReception").GetComponent<Button>();
            test.onClick.AddListener(GoToReception);
            receptionButton=true;     
            Debug.Log("im in room now");
            //why does this show up in the reception 
        }

       
        // // if in "RoomLocked" when click on killGuest go to room
        // // if in "RoomLocked" when click on ButtonReception go to reception
        // if(!getGuestKilled() && SceneManager.GetActiveScene().name.Equals("RoomLocked") ){
            
        //     Button test2 =  GameObject.Find("KillGuest").GetComponent<Button>();
        //     test2.onClick.AddListener(GoToRoom);
        //     guestKilled = true;
        //    // killButton = true;
        //     receptionButton = false;
        // }

        //  if(!receptionButton  && !getGuestKilled() && SceneManager.GetActiveScene().name.Equals("RoomLocked") ){
        //     Button test1 =  GameObject.Find("ButtonReception").GetComponent<Button>();
        //     test1.onClick.AddListener(GoToReception);
        //     receptionButton=true;
        //   //  killbutton = false;
        //     guestKilled = false;
        //     Debug.Log("go to reception");
            
        // }

if (SceneManager.GetActiveScene().name.Equals("RoomLocked")) {
    Button test2 = GameObject.Find("ButtonKill").GetComponent<Button>();
    Button test1 = GameObject.Find("ButtonReception").GetComponent<Button>();

    // Check if "KillButton" button is clicked
 
 if(!killButton){
    test2.onClick.AddListener(() => {
        Invoke("GoToRoom", 5f);
  		Debug.Log("Go to room");
    });
    killButton =true;
}

//for reception 
if (!receptionButton2){

    // Check if "ButtonReception" button is clicked
    test1.onClick.AddListener(() => {
        GoToReception();
       Debug.Log("Go to reception");
     });
     
       receptionButton2 = true;
    }
     
}//endRoomLocked


        // if in "Reception" and offer is not accepted, assign the room button (goes to room)
        if(!roomButton && !getAccepted() && SceneManager.GetActiveScene().name.Equals("Reception")){
            Button test =  GameObject.Find("ButtonRoom").GetComponent<Button>();
            test.onClick.AddListener(GoToRoom);
            roomButton=true;
        }

        //if in "Reception" and offer is accepted, assign the the room button (goes to the locked room)
        if(!roomButton2 && getAccepted() && SceneManager.GetActiveScene().name.Equals("Reception")){
            Button test =  GameObject.Find("ButtonRoom").GetComponent<Button>();
            test.onClick.RemoveAllListeners();
            test.onClick.AddListener(GoToRoomN);
            roomButton2=true;
            // goes back to room after 10 seconds
            Invoke("roomEmpty", 30f);

        }

    }

    public void roomEmpty(){
        hasAccepted =false;
    }

    public void setHasAccepted (){
        hasAccepted = true;
    }

    public bool getAccepted(){
        return hasAccepted;
    }

    public void setGuestKilled(){
        guestKilled = true;
    }
    
    bool getGuestKilled(){

         return guestKilled;
    }

    public void GoToReception(){
        SceneManager.LoadScene("Reception");
    }

    public void GoToRoom(){
        SceneManager.LoadScene("Room");
    }

    public void GoToRoomN(){
        SceneManager.LoadScene("RoomLocked");
    }

    public void StartGame(){
        SceneManager.LoadScene("Story");
    }



}
