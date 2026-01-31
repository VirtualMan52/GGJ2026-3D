using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Slot
{
    public GameObject beginWith;
    public GameObject objAt;
    public Vector3 pos;

    public void Initialize()
    {
        GameObject c = GameObject.Instantiate(beginWith);
        c.transform.parent = null;
        c.transform.position = pos;
        objAt = c;

        if (c.GetComponent<SlotFollowerScript>())
        {
            c.GetComponent<SlotFollowerScript>().ChangeSlot(this);
        }
    }
}
