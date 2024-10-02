using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class StartupMode : MonoBehaviour
{
    [SerializeField] string nextMode = "Scan";
    //loads startup UI, initalising screen.
    private void OnEnable()
    {
        UIController.ShowUI("Startup");
    }

    // first checks if phone supports AR
    // proceeds to next mode or tells user the device is unsuitable
    private void Update()
    {
        if (ARSession.state == ARSessionState.Unsupported)
        {
            InteractionController.EnableMode("NonAR");
        }
        else if(ARSession.state >= ARSessionState.Ready)
        {
            InteractionController.EnableMode(nextMode);
        }
    }
}
