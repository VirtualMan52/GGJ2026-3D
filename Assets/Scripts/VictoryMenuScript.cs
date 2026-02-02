using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryMenuScript : MonoBehaviour
{
    public string nextScene = "MainMenu";

    public void LoadNextScene()
    {
        SceneManager.LoadScene(nextScene);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
