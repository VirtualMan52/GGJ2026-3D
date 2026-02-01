using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryMenuScript : MonoBehaviour
{
    public string nextScene = "StartMenuGame";

    public void LoadNextScene()
    {
        SceneManager.LoadScene(nextScene);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("StartMenuGame");
    }
}
