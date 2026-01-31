using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private GameObject canvasStarterMenu;
    [SerializeField] private GameObject canvasLevelMenu;


    public void PlayGame(string Level1)
    {
        SceneManager.LoadScene(Level1);
    }

    public void LevelSectionOpenning()
    {
        if(canvasStarterMenu != null)
        {
            canvasStarterMenu.SetActive(false);
        }
        if(canvasLevelMenu != null)
        {
            canvasLevelMenu.SetActive(true);
        }
    }

    public void ReturnAction()
    {
        canvasLevelMenu.SetActive(false);
        canvasStarterMenu.SetActive(true);
    }

    public void LevelClicking(string LevelNumber)
    {
        SceneManager.LoadScene(LevelNumber);
    }

   public void QuitGame()
    {
        Application.Quit();
    }
}
