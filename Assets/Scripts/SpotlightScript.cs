using UnityEngine;

public class SpotlightScript : MonoBehaviour
{

    [SerializeField] private int slotIndex;
    [SerializeField] private RingScript ring;

    private SlotFollowerScript slotFollower;

    void Update()
    {
        if (slotFollower)
        {
            transform.rotation = Quaternion.LookRotation(slotFollower.transform.position - transform.position);
        }
        else
        {
            if (ring._slots[slotIndex].objAt)
            {
                slotFollower = ring._slots[slotIndex].objAt.GetComponent<SlotFollowerScript>();
            }
        }
    }
}
