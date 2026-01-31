using UnityEngine;

public class SlotFollowerScript : MonoBehaviour
{
    private Slot _slotToFollow;
    public int highlight = 0;

    [SerializeField] private CircleRenderer _highlightIndicator;

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position,_slotToFollow.pos,0.125f);

        if (_highlightIndicator)
        {
            if (highlight > 0)
            {
                highlight--;
                _highlightIndicator.radius = Mathf.Lerp(_highlightIndicator.radius, 0.5f, 0.125f);
            }
            else _highlightIndicator.radius = Mathf.Lerp(_highlightIndicator.radius, 0f, 0.125f);
        }
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
