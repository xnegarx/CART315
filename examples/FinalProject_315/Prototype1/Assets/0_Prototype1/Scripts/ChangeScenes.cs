using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{


public void GoToCounter(){
    SceneManager.LoadScene("Reception");

}

public void GoToRoom(){
    SceneManager.LoadScene("Room");

}




}
