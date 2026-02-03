using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryMenuScript : MonoBehaviour
{
    public string nextScene = "MainMenu";

    public void LoadNextScene()
    {
        TransitionScript.TransitionTo(nextScene);
    }

    public void BackToMenu()
    {
        TransitionScript.TransitionTo("MainMenu");
    }
}
