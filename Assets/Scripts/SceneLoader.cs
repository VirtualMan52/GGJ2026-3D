using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private GameObject canvasStarterMenu;
    [SerializeField] private GameObject canvasLevelMenu;
    [SerializeField] private GameObject canvasOptionsMenu;


    public void PlayGame(string Level1)
    {
        SceneManager.LoadScene(Level1);
    }

    public void LevelSectionOpenning()
    {    
        canvasLevelMenu.SetActive(true);
        canvasStarterMenu.SetActive(false);
        canvasOptionsMenu.SetActive(false);
    }

    

    public void OptionsMenuOpenning()
    {
        if(canvasLevelMenu != null)
        {
            canvasLevelMenu.SetActive(false);
        }
        canvasStarterMenu.SetActive(false);
        canvasOptionsMenu.SetActive(true);
    }
    
    public void ReturnAction()
    {
        if(canvasLevelMenu != null)
        {
            canvasLevelMenu.SetActive(false);
        }
        canvasStarterMenu.SetActive(true);
        canvasOptionsMenu.SetActive(false);
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
