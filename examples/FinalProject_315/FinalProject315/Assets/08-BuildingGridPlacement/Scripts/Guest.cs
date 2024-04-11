using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Guest : MonoBehaviour
{
    
    public GameObject guest;

   [SerializeField] public BuildingButtons offerButtons;
        // Start is called before the first frame update
    void Start()
    {
        HideGuest();
        Invoke("ShowGuest", 10f);

    }
    

void ShowGuest(){
        guest.SetActive(true);
       offerButtons.Show();

}


public void HideGuest(){
     guest.SetActive(false);
    offerButtons.Hide();
}




    // Update is called once per frame
    void Update()
    {
        
    }
}
