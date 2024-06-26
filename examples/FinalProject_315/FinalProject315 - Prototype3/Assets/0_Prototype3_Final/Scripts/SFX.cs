using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SFX : MonoBehaviour
{

    private AudioSource clickSound;
    private AudioSource killSound;

    private bool killSoundPlayed = false;


    // Start is called before the first frame update
    void Start()
    {
                clickSound = this.GetComponent<AudioSource>();
                killSound = this.GetComponent<AudioSource>();
    }

    public void PlayClickSound(){
        clickSound.Play();
    }

    public void PlayKillSound(){


        if(!killSoundPlayed){
        killSound.Play();
        killSoundPlayed = true;
    }
    }
}

