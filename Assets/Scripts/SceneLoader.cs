using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private GameObject canvasStarterMenu;
    [SerializeField] private GameObject canvasLevelMenu;

    public GameObject AudioPrefab;

    public void PlayGame(string Level1)
    {
        if (VolumeSettings.settingsOpen) return;
        SceneManager.LoadScene(Level1);
    }

    public void LevelSectionOpenning()
    {
        if (VolumeSettings.settingsOpen) return;
        canvasLevelMenu.SetActive(true);
        canvasStarterMenu.SetActive(false);
    }

    

    public void OptionsMenuOpenning()
    {
        if (!VolumeSettings.settingsOpen) Instantiate(AudioPrefab);
    }
    
    public void ReturnAction()
    {
        if(canvasLevelMenu != null)
        {
            canvasLevelMenu.SetActive(false);
        }
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
