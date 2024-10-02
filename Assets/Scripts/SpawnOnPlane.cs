using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


public class SpawnOnPlane : MonoBehaviour
{
    // Start is called before the first frame update
    

    ARRaycastManager raycaster;
    GameObject spawnedObject;
    List<GameObject> placedPrefabList = new List<GameObject>();
    [SerializeField] private int maxPrefabSpawnCount = 0;
    private int placedPrefabCount;
    [SerializeField] GameObject placedPrefab;
    List<ARRaycastHit> hits = new List<ARRaycastHit>();


    void Awake()
    {
        raycaster = GetComponent<ARRaycastManager>();

    }

    // This function is just used to detect if the user has touched the screen 
    // and also where they have touched it
    bool TryGetTouchPosition(out Vector2 touchPosition) 
    {
        if (Input.GetTouch(0).phase == TouchPhase.Began)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }
        touchPosition = default;
        return false;
    }



    
    void Update()
    {
        // nothing will happen if user does not touch screen 
        if(!TryGetTouchPosition(out Vector2 touchPosition)) 
        {
            return;
        }

        // below checks if the raycast has hit a plane from the touchposition to the scene.
        if (raycaster.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            Pose hitPose = hits[0].pose;
            if(placedPrefabCount < maxPrefabSpawnCount)
            {
                SpawnPrefab(hitPose);
            }
                        
        }
    }
    //switch between the different objects - user input
    public void SetPrefabType(GameObject prefabType) 
    {
        placedPrefab = prefabType;
    }

    // this function allows multiple objects to be placed on a scene
    // it instantiates an object and keeps track of how many
    // objects have been placed using a count and a list
    private void SpawnPrefab(Pose hitPose)
    {
        spawnedObject = Instantiate(placedPrefab, hitPose.position, hitPose.rotation * Quaternion.Euler(0f, 180f, 0f));
        
        placedPrefabList.Add(spawnedObject);
        placedPrefabCount++;
    }

    // Function below removes the last object that was placed on the scene
    public void DestroyObj()
    {
        placedPrefabList.Reverse();
        GameObject removedObj = placedPrefabList[0];
        GameObject.Destroy(removedObj);
        placedPrefabList.Remove(removedObj);
        placedPrefabCount--;
    }

}
