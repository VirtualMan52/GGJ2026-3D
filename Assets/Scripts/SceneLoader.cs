using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{



    public void PlayGame(string EntryGameScene)
    {
        SceneManager.LoadScene(EntryGameScene);
    }



   public void QuitGame()
    {
        Application.Quit();
    }
}
