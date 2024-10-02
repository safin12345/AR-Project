using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RotaryHeart.Lib.SerializableDictionary;
using DG.Tweening;

[System.Serializable]
// The code below is used as part of the framework for the user interface
// it is a reusable framework created by jonathan linowes.
// allows you to manipulate your UI similar to how he did.
public class UIPanelDictionary: SerializableDictionaryBase<string, CanvasGroup> 

{
}

public class UIController : Singleton<UIController>
{
    [SerializeField] UIPanelDictionary uiPanels;
    CanvasGroup currentPanel;

    void Awake()
    {
        base.Awake();
        ResetAllUI();
    }

    void ResetAllUI() 
    {
        foreach(CanvasGroup panel in uiPanels.Values) 
        {
            panel.gameObject.SetActive(false);
        }
    }

    public static void ShowUI(string name) 
    {
        Instance?._ShowUI(name);
    }

    void _ShowUI(string name) 
    {
        CanvasGroup panel;
        if(uiPanels.TryGetValue(name, out panel)) 
        {
            ChangeUI(uiPanels[name]);
        }
        else 
        {
            Debug.LogError("Undefined UI panel " + name);
        }
    }

    void ChangeUI(CanvasGroup panel)
    {
        if (panel == currentPanel)
        {
            return;
        }
        if (currentPanel)
        {
            FadeOut(currentPanel);
            //currentPanel.gameObject.SetActive(false);
        }
        currentPanel = panel;

        if (panel)
        {
            FadeIn(panel);
            //panel.gameObject.SetActive(true);
        }
    }

    void FadeIn(CanvasGroup panel) 
    {
        panel.gameObject.SetActive(true);
        panel.DOFade(1f, 0.5f);
    }

    void FadeOut(CanvasGroup panel)
    {
        panel.DOFade(0f, 0.5f).OnComplete(() => panel.gameObject.SetActive(false));
    }    
}

