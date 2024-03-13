using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISelectStage : MonoBehaviour
{
    [SerializeField] Button _MainMenu;

    void Start()
    {
        _MainMenu.onClick.AddListener(LoadMainMenu);
    }

    private void LoadMainMenu()
    {
        scenesManager.Instance.LoadMainMenu ();
        //Taro di dalem loadScene kalo perlu --> scenesManager.Scene.SelectStage
    } 
}
