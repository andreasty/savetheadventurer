using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public SceneManagerScript sceneManager;

    // Method untuk memuat MainMenu
    public void LoadMainMenu()
    {
        sceneManager.LoadScene("MainMenu");
    }

    // Method untuk memuat SelectStage
    public void LoadSelectStage()
    {
        sceneManager.LoadScene("SelectStage");
    }

    // Method untuk memuat SelectLevel
    public void LoadSelectLevel()
    {
        sceneManager.LoadScene("SelectLevel");
    }

    // Method untuk memuat Level1
    public void LoadLevel1()
    {
        sceneManager.LoadScene("Level1");
    }
}
