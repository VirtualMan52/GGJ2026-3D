using UnityEngine;

public class SlotFollowerScript : MonoBehaviour
{
    private Slot _slotToFollow;

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position,_slotToFollow.pos,0.125f);
    }

    public void ChangeSlot(Slot s)
    {
        _slotToFollow = s;
        s.objAt = gameObject;
    }

    public Slot GetSlot()
    {
        return _slotToFollow;
    }
}
