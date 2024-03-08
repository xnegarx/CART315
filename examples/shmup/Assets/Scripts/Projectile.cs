using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float moveSpeed;
    public GameObject enemy1d;
    public GameObject enemy2d;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "enemy1"){
            Instantiate(enemy1d, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

      if(collision.gameObject.tag == "enemy2"){
            Instantiate(enemy2d, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if(collision.gameObject.tag == "topWall"){
            Destroy(gameObject);
        }
    }
}
