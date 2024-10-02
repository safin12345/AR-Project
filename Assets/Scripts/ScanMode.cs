using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.SceneManagement;

public class ScanMode : MonoBehaviour
{
    [SerializeField] ARPlaneManager planeManager;

    //when prompted the scanning text will appear
    private void OnEnable()
    {
        UIController.ShowUI("Scan");
    }

    //it will prompt main mode if planes are detected.
    void Update()
    {
        if(planeManager.trackables.count > 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
