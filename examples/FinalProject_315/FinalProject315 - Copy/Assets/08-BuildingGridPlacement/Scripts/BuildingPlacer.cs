using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class BuildingPlacer : MonoBehaviour
{
    public static BuildingPlacer instance; // (Singleton pattern)


    public LayerMask groundLayerMask;

    protected GameObject _buildingPrefab;
    protected GameObject _toBuild;

    protected Camera _mainCamera;

    protected Ray _ray;
    protected RaycastHit _hit;

    public GameObject manager;

    private void Awake()
    {
        instance = this; // (Singleton pattern)
        _mainCamera = Camera.main;
        _buildingPrefab = null;
        
      
    }

    void Start()
    {
   
    //DontDestroyOnLoad(gameObject); // Make the BuildingPlacer persistent across scenes

    

    }

    private void Update()
    {
        if (_buildingPrefab != null)
        { // if in build mode

            // right-click: cancel build mode
            if (Input.GetMouseButtonDown(1))
            {
                Destroy(_toBuild);
                _toBuild = null;
                _buildingPrefab = null;
                return;
            }

            // hide preview when hovering UI
            if (EventSystem.current.IsPointerOverGameObject())
            {
                if (_toBuild.activeSelf) _toBuild.SetActive(false);
                return;
            }
            else if (!_toBuild.activeSelf) _toBuild.SetActive(true);

            // rotate preview with Spacebar
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _toBuild.transform.Rotate(Vector3.up, 90);
            }

            _ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(_ray, out _hit, 1000f, groundLayerMask))
            {
                if (!_toBuild.activeSelf) _toBuild.SetActive(true);
                _toBuild.transform.position = _hit.point;

                if (Input.GetMouseButtonDown(0))
                { // if left-click
                    BuildingManager m = _toBuild.GetComponent<BuildingManager>();
                    if (m.hasValidPlacement)
                    {
                        
                        m.SetPlacementMode(PlacementMode.Fixed);
                        //SABINE
                        m.isSetInitial=true;

                        // shift-key: chain builds
                        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                        {
                            _toBuild = null; // (to avoid destruction)
                            _PrepareBuilding();
                        }
                        // exit build mode
                        else
                        {
                            _buildingPrefab = null;
                            _toBuild = null;
                        }
                    }
                }

            }
            else if (_toBuild.activeSelf) _toBuild.SetActive(false);
        }
    }

    public void SetBuildingPrefab(GameObject prefab)
    {

        //check how many items of that type in inventory

   

        _buildingPrefab = prefab;
            
        _PrepareBuilding();
    
        EventSystem.current.SetSelectedGameObject(null); // cancel keyboard UI nav
    }

    protected virtual void _PrepareBuilding()


    {
        



        if (_toBuild) Destroy(_toBuild);

    
        _toBuild = Instantiate(_buildingPrefab);
        
        _toBuild.SetActive(false);



        BuildingManager m = _toBuild.GetComponent<BuildingManager>();
        Item.ItemType itemType = m.itemType;



         if (!manager.GetComponent<Inventory>().HasItemType(itemType)) {
        Debug.Log("Inventory does not contain the required item type. Cannot build.");
        Destroy(_toBuild); // Destroy the newly instantiated building
        return; // Exit the method if the required item type is not in the inventory list or its quantity is insufficient
    }
       // Debug.Log(manager);
       // Inventory inventory = manager.GetComponent<Inventory>();
       // Debug.Log(inventory);
        bool returned =  manager.GetComponent<Inventory>().RemoveFromInventory(itemType); 
        if(returned == true){
        Debug.Log("hello");
        Debug.Log(returned);
        m.isFixed = false;
        m.SetPlacementMode(PlacementMode.Valid);



        }
        else{
           
           if (_toBuild) Destroy(_toBuild);
         

        }


                       if( SceneManager.GetActiveScene().name.Equals("Room")){
                        _toBuild.SetActive(true);
                        } else if(SceneManager.GetActiveScene().name.Equals("Reception")) {
                        _toBuild.SetActive(false);
                        }
    }

}

