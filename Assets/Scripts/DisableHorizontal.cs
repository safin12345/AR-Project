using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class DisableHorizontal : MonoBehaviour
{
    void OnEnable()
    {
        GetComponent<ARPlaneManager>().planesChanged += OnPlaneAdded;
    }

    void OnDisable()
    {
        GetComponent<ARPlaneManager>().planesChanged -= OnPlaneAdded;
    }

    void OnPlaneAdded(ARPlanesChangedEventArgs eventArgs)
    {
        foreach (var plane in eventArgs.added)
            DisableIfHorizontal(plane);
    }

    void DisableIfHorizontal(ARPlane plane)
    {
        // check if the plane is horizontal.
        if (plane.alignment == PlaneAlignment.HorizontalDown || plane.alignment == PlaneAlignment.HorizontalUp)
        {
            // Disable the entire GameObject.
            plane.gameObject.SetActive(false);
        }
    }
}
