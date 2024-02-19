using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoring : MonoBehaviour
{

    public int lives = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


  
        private void OnTriggerEnter2D(Collider2D collision){

        if (collision.gameObject.tag == "enemy1" || collision.gameObject.tag == "enemy2"){
            lives -= 1;

            Destroy(collision.gameObject);

            if (lives <= 0){
                Destroy(gameObject);
            }
        }
    }
}
