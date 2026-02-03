using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject AudioPrefab;

    public void MainMenu()
    {
        TransitionScript.TransitionTo("MainMenu");
    }

    public void LoadLevel(string name)
    {
        TransitionScript.TransitionTo(name);
    }

    public void Audio()
    {
        if (WinConditionScript.Singleton && WinConditionScript.Singleton.levelComplete) return;
        if (VolumeSettings.settingsOpen) return;

        Instantiate(AudioPrefab);
    }

    public void Restart()
    {
        TransitionScript.TransitionTo(SceneManager.GetActiveScene().name);
    }
}
