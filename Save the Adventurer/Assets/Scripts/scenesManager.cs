using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenesManager : MonoBehaviour
{
    public static scenesManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public enum Scene
    {
        MainMenu,
        SelectStage,
        SelectLevel
    }

    public void loadScene(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }

    public void LoadSelectStage()
    {
        SceneManager.LoadScene(Scene.SelectStage.ToString());
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(Scene.MainMenu.ToString());
    }

    public void LoadSelectLevel()
    {
        SceneManager.LoadScene(Scene.SelectLevel.ToString());
    }
}
