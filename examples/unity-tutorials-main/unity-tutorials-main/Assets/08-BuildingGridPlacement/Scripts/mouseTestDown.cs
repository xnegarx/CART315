using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class mouseTestDown : MonoBehaviour
{
    // Start is called before the first frame update
    bool isDown=true;
     private Camera cam;
     BuildingManager m;
    public LayerMask groundLayerMask;
    
    
    protected Camera _mainCamera;

    protected Ray _ray;
    protected RaycastHit _hit;

    protected Vector3 originalPos;




    void Start()
    {
          _mainCamera = Camera.main;
          m = gameObject.GetComponent<BuildingManager>();
    }

    // Update is called once per frame
    void Update()
    {
    

        // ** mouse over ** //
          if(isDown ==false && m.isSetInitial ==true){
             Debug.Log("hello mouse moving");
            //update the Position
            _ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(_ray, out _hit, 1000f, groundLayerMask))
                gameObject.transform.position = _hit.point;
           }


        //mouse up
         if(Input.GetMouseButtonUp(0)&& m.isSetInitial ==true){

            if(isDown ==false){
             Debug.Log("hello mouse up");
            isDown = true;
            //update the Position
             _ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(_ray, out _hit, 1000f, groundLayerMask))
                gameObject.transform.position = _hit.point;
                //m.setFromMouse("fixed");
                Debug.Log(m.hasValidPlacement);
                if(m.hasValidPlacement){
                  m.setFromMouse("fixed");
                }
                else{
                   gameObject.transform.position = originalPos;
                    m.setFromMouse("fixed");

                }
           }
         }

        
    }

//Initial mouse down
    void OnMouseDown(){
      if(m.isSetInitial ==true){
        originalPos = gameObject.transform.position;
         Debug.Log("hello mouse down");
            isDown =false;
            m.isFixed = false;
            m.setFromMouse("valid");
           _ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
          if (Physics.Raycast(_ray, out _hit, 1000f, groundLayerMask))
                gameObject.transform.position = _hit.point;
      }

    }
} //class
