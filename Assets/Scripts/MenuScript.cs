using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject AudioPrefab;

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Audio()
    {
        if (WinConditionScript.Singleton && WinConditionScript.Singleton.levelComplete) return;
        if (VolumeSettings.settingsOpen) return;

        Instantiate(AudioPrefab);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
