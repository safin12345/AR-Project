using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using TMPro;
public class Distance : MonoBehaviour
{

    public List<GameObject> Points = new List<GameObject>();
    public GameObject Text;
    ARRaycastManager raycaster;
    GameObject spawnedObject;
    [SerializeField] private int maxPrefabSpawnCount = 0;
    private int placedPrefabCount;
    [SerializeField] GameObject placedPrefab;
    List<ARRaycastHit> hits = new List<ARRaycastHit>();

    // Start is called before the first frame update
    void Awake()
    {
        raycaster = GetComponent<ARRaycastManager>();

    }

    // below retrieves the touch position of the user
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
        if (!TryGetTouchPosition(out Vector2 touchPosition))
        {
            return;
        }

        // below checks if the raycast has hit a plane from the touchposition to the scene.
        if (raycaster.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            Pose hitPose = hits[0].pose;
            if (placedPrefabCount < maxPrefabSpawnCount)
            {
                PointDistance(hitPose);
            }

        }
    }

    void PointDistance(Pose hitPose) 
    {
        spawnedObject = Instantiate(placedPrefab, hitPose.position, hitPose.rotation);
        Points.Add(spawnedObject);
        // This connects the line renderers if there are 2 (or more) points 
        
        if (Points.Count >= 2)
        {
            LineRenderer lr = spawnedObject.GetComponent<LineRenderer>();
            lr.positionCount = 2;
            lr.SetPosition(0, spawnedObject.transform.position);
            lr.SetPosition(1, Points[Points.Count - 2].transform.position);

            // Places text on the line renderer where it is halfway between the two points.
            var temp = Instantiate(Text, (spawnedObject.transform.position + Points[Points.Count - 2].transform.position) / 2, Quaternion.identity);

            temp.transform.LookAt(spawnedObject.transform.position);
            temp.transform.localEulerAngles = new Vector3(90, temp.transform.localEulerAngles.y + 90, 0);

            TextMesh myText = temp.GetComponent<TextMesh>();

            //stays as cm by default
            myText.text = (Vector3.Distance(spawnedObject.transform.position, Points[Points.Count - 2].transform.position) * 100).ToString("0.00");
            

        }
        

    }

    // The below functions change the metrics to the corresponding units.
    public void Metres() 
    {
        var temp = Instantiate(Text, (spawnedObject.transform.position + Points[Points.Count - 2].transform.position) / 2, Quaternion.identity);

        temp.transform.LookAt(spawnedObject.transform.position);
        temp.transform.localEulerAngles = new Vector3(90, temp.transform.localEulerAngles.y + 90, 0);

        TextMesh myText = temp.GetComponent<TextMesh>();
        myText.text = (Vector3.Distance(spawnedObject.transform.position, Points[Points.Count - 2].transform.position) * 10).ToString("0.00");

    }

    public void Milimetres()
    {
        var temp = Instantiate(Text, (spawnedObject.transform.position + Points[Points.Count - 2].transform.position) / 2, Quaternion.identity);
        temp.transform.LookAt(spawnedObject.transform.position);
        temp.transform.localEulerAngles = new Vector3(90, temp.transform.localEulerAngles.y + 90, 0);
        TextMesh myText = temp.GetComponent<TextMesh>();
        myText.text = (Vector3.Distance(spawnedObject.transform.position, Points[Points.Count - 2].transform.position) * 1000).ToString("0.00");

    }

    public void Centimetres()
    {
        var temp = Instantiate(Text, (spawnedObject.transform.position + Points[Points.Count - 2].transform.position) / 2, Quaternion.identity);
        temp.transform.LookAt(spawnedObject.transform.position);
        temp.transform.localEulerAngles = new Vector3(90, temp.transform.localEulerAngles.y + 90, 0);
        TextMesh myText = temp.GetComponent<TextMesh>();
        myText.text = (Vector3.Distance(spawnedObject.transform.position, Points[Points.Count - 2].transform.position) * 100).ToString("0.00");

    }
}
