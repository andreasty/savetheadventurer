using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISelectLevel : MonoBehaviour
{
    [SerializeField] Button _SelectLevel;

    void Start()
    {
        _SelectLevel.onClick.AddListener(LoadLevelMenu);
    }

    private void LoadLevelMenu()
    {
        scenesManager.Instance.loadScene(scenesManager.Scene.SelectLevel);
        //Taro di dalem loadScene kalo perlu --> scenesManager.Scene.SelectStage
    }
}


