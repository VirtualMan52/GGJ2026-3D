using UnityEngine;

public class LoverScript : MonoBehaviour
{
    private void Awake()
    {
        WinConditionScript.Singleton.lovers.Add(this);
    }
}
