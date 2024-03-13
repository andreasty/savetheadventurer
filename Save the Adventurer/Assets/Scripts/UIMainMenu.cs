using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] Button _SelectStage;

    void Start()
    {
        _SelectStage.onClick.AddListener(SelectStageMenu);
    }

    private void SelectStageMenu()
    {
        scenesManager.Instance.LoadSelectStage();
        //Taro di dalem loadScene kalo perlu --> scenesManager.Scene.SelectStage
        
    }
}


