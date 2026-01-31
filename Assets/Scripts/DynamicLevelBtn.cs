using UnityEngine;
using UnityEngine.SceneManagement;

public class DynamicLevelBtn : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log(SceneManager.sceneCountInBuildSettings);
    }

    
}
