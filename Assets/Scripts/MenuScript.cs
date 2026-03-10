using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject AudioPrefab;
    public GameObject[] canvases;

    public void MainMenu()
    {
        if (!VolumeSettings.settingsOpen) TransitionScript.TransitionTo("MainMenu");
    }

    public void LoadLevel(string name)
    {
        if (!VolumeSettings.settingsOpen) TransitionScript.TransitionTo(name);
    }

    public void Audio()
    {
        if (WinConditionScript.Singleton && WinConditionScript.Singleton.levelComplete) return;
        if (VolumeSettings.settingsOpen) return;

        Instantiate(AudioPrefab);
    }

    public void Restart()
    {
        if (!VolumeSettings.settingsOpen) TransitionScript.TransitionTo(SceneManager.GetActiveScene().name);
    }

    public void ToggleMenu()
    {
        if (VolumeSettings.settingsOpen) return;
        foreach (GameObject go in canvases)
        {
            go.SetActive(!go.activeSelf);
        }
    }
}
