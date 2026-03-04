using UnityEngine;
using System.Collections.Generic;
using System;

public class SwappableScript : MonoBehaviour
{
    [SerializeField] private CircleRenderer _rangeIndicator;
    [SerializeField] private SphereCollider _trigger;
    public float swapRange;

    public List<GameObject> reachable = new List<GameObject>();

    public void Start()
    {
        _rangeIndicator.radius = swapRange;

        _trigger = GetComponent<SphereCollider>();
        _trigger.radius = swapRange;

        gameObject.AddComponent<Rigidbody>().isKinematic = true; // Allows collision events

        // Tell swapper you're available
        SwapperScript.Singleton.AddSwappable(this);
    }

    public void Update()
    {
        foreach (GameObject go in reachable)
        {
            if (CanSwap(go)) go.SendMessage("Highlighted", "Reachable");
        }
    }

    public bool CanSwap(GameObject other)
    {
        if (Vector3.Distance(transform.position, other.transform.position) > swapRange + 0.2f) return false;
        return true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<SlotFollowerScript>() || other.GetComponent<MaskTableScript>())
        {
            if (!reachable.Contains(other.gameObject)) reachable.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (reachable.Contains(other.gameObject)) reachable.Remove(other.gameObject);
    }
}
