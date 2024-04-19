using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StateVariables : MonoBehaviour
{
    public int rent;
    public int money;
    public int kills;

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name.Equals("Reception")){
            GameObject.Find("rent").GetComponent<TextMeshProUGUI>().SetText("rent: " + rent.ToString());
            GameObject.Find("money").GetComponent<TextMeshProUGUI>().SetText("money: " + money.ToString());
            GameObject.Find("kills").GetComponent<TextMeshProUGUI>().SetText(kills.ToString());
        }
        if(SceneManager.GetActiveScene().name.Equals("RoomLocked")){
            GameObject.Find("rent").GetComponent<TextMeshProUGUI>().SetText("rent: " + rent.ToString());
            GameObject.Find("money").GetComponent<TextMeshProUGUI>().SetText("money: " + money.ToString());
            GameObject.Find("kills").GetComponent<TextMeshProUGUI>().SetText(kills.ToString());
        }



    }

}
