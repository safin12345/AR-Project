using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonARMode : MonoBehaviour
{
    //displays the NonAR UI - tells user the device unsupported
    private void OnEnable()
    {
        UIController.ShowUI("NonAR");
    }
}
