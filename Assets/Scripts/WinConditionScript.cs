using System.Collections.Generic;
using UnityEngine;

public class WinConditionScript : MonoBehaviour
{
    public List<LoverScript> lovers = new List<LoverScript>();

    public bool levelComplete = false;

    private static WinConditionScript _singleton;
    public static WinConditionScript Singleton
    {
        get => _singleton;
        private set
        {
                _singleton = value;
        }
    }
    private void Awake()
    {
        Singleton = this;
    }

    private void Update()
    {
        if (!levelComplete)
        {
            levelComplete = CheckLevelComplete();
            if (levelComplete) Debug.Log("Completed!");
        }
    }

    private bool CheckLevelComplete()
    {
        if (lovers.Count == 0) return false;
        foreach (LoverScript l in lovers)
        {
            bool hasPlayer = false;
            SlotFollowerScript sf = l.GetComponent<SlotFollowerScript>();
            RingScript ring = sf.GetSlot().ring;

            foreach (Slot s in ring._slots)
            {
                if (s.objAt.GetComponent<SwappableScript>()) hasPlayer = true;
            }

            if (!hasPlayer) return false;
        }
        return true;
    }
}
