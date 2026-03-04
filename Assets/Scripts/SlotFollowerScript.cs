using UnityEngine;

public class SlotFollowerScript : MonoBehaviour
{
    private Slot _slotToFollow;

    private int _reachable = 0;
    private int _hovered = 0;

    public bool swappable = true;

    [SerializeField] private CircleRenderer _highlightIndicator;

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position,_slotToFollow.pos,0.125f);

        if (_highlightIndicator)
        {
            float desiredRadius = 0f;

            if (_reachable > 0)
            {
                _reachable--;
                desiredRadius = 0.5f;
            }
            if (_hovered > 0)
            {
                _hovered--;
                desiredRadius = 0.75f;
            }

            _highlightIndicator.radius = Mathf.Lerp(_highlightIndicator.radius, desiredRadius, 0.125f);
        }
    }

    public void Highlighted(string type)
    {
        if (type == "Reachable") _reachable = 2;
        if (type == "Hovered") _hovered = 2;
        if (type == "Clicked" && _highlightIndicator) _highlightIndicator.radius = 0.625f;
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
