using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraManager : MonoBehaviour
{
    private bool changeCamera = false;
    public Camera main;

    // Start is called before the first frame update
    void Start()
    {
           // Check if we are in Scene 1
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            GameObject.DontDestroyOnLoad(gameObject);
        } 


       // Debug.Log(SceneManager.GetActiveScene().buildIndex);



    }

    // Update is called once per frame
    void Update()
    {

        if(SceneManager.GetActiveScene().buildIndex == 3 && changeCamera == false ){

        transform.position = new Vector3(24.6f, 25f, -24.6f);

        transform.rotation = Quaternion.Euler(30, -45, 0);

        main.orthographicSize = 21.6f;

        changeCamera = true;
        
        }

        if(SceneManager.GetActiveScene().buildIndex == 4 && changeCamera == true ){

        transform.position = new Vector3(0f, 0f, -10f);

        transform.rotation = Quaternion.Euler(0, 0, 0);

        main.orthographicSize = 5f;

        changeCamera = false;

        }



}

        
    }

