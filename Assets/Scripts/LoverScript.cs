using UnityEngine;

public class LoverScript : MonoBehaviour
{
    private void Start()
    {
        WinConditionScript.Singleton.lovers.Add(this);
    }
}
