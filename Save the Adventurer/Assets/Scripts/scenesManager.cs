using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    // Method untuk memuat scene dengan nama tertentu
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
