using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryScreen : MonoBehaviour
{
    [SerializeField]VoidEventChannel levelClearEvent;
    [SerializeField] Button nextSceneButton;

    private void OnEnable()
    {
        levelClearEvent.AddListener(ShowUI);
        nextSceneButton.onClick.AddListener(SceneLoader.NextScene);
    }

    private void OnDisable()
    {
        levelClearEvent.removeListener(ShowUI);
        nextSceneButton.onClick.RemoveListener(SceneLoader.NextScene);
    }

    private void ShowUI()
    {
        GetComponent<Canvas>().enabled = true;
        GetComponent<Animator>().enabled = true;
    }

    
}
