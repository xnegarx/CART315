using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    
    private AudioSource musicSource;
    private bool isPlaying = false;

    private void Awake(){

             if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            GameObject.DontDestroyOnLoad(gameObject);
        } 
    }

    void Start(){ 
        musicSource = this.GetComponent<AudioSource>();
        //musicSource.Pause();
        Debug.Log("music");
    }
    
    void Update(){

              if (SceneManager.GetActiveScene().buildIndex == 3 && isPlaying == false)
        {
    
                musicSource.Play();
                isPlaying = true;
        } 
        
        else if (SceneManager.GetActiveScene().buildIndex != 3){
                musicSource.Pause(); 
                isPlaying = false;
        }
   
    }


}
