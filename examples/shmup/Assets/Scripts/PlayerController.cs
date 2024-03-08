using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = .05f;
    private float xPos;

    public float leftWall, rightWall;

    public KeyCode leftKey, rightKey;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       

        if(Input.GetKey(rightKey)){
            if(xPos < rightWall){
                xPos += moveSpeed;
            }
        }

        if(Input.GetKey(leftKey)){
            if(xPos > leftWall){
            xPos -= moveSpeed;
            }
        }

         transform.localPosition = new Vector3(xPos, transform.position.y, 0);

    }



}
