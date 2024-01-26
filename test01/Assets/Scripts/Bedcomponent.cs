using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bedcomponent : MonoBehaviour
{
    public SpriteRenderer sr;
    public float xLoc = 0;
    public float bedSpeed = .1f;

    // Start is called before the first frame update
    void Start()
    {
        sr = this.GetComponent<SpriteRenderer>();
        sr.color = Color.gray;
        
    }

    // Update is called once per frame
    void Update()
    {
    if (Input.GetKey(KeyCode.Z) && xLoc < 9f) {

xLoc -= .01f;
            }
    if (Input.GetKey(KeyCode.X)) {

xLoc += .01f;
            }
                    this.transform.position = new Vector3(xLoc, transform.position.y, transform.position.z);
        
    }

    private void OnCollisionEnter2D(OnCollisionEnter2D)(Collision2D other) {
        Debug.Log(other.gameObject.name);
    }
}
