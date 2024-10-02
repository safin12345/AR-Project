using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{

    public static T Instance { get; private set; }
    // Start is called before the first frame update

    public static bool isIntitialized 
    {
        get {return Instance != null; }
    }

    protected virtual void Awake()
    { 
    
        if(Instance != null) 
        {
            Debug.LogError($"Trying to instantiate a second instance of singleton class{GetType().Name}");
        }
        else
        {
            Instance = (T)this;
        }
    }

    protected virtual void onDestroy() 
    {
        if (Instance == this)
        {
            Instance = null;
        }
    
    }

}
