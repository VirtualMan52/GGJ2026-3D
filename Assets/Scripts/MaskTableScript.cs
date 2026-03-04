using UnityEngine;

public class MaskTableScript : MonoBehaviour
{
    public MaskHolder mask;
    private int _reachable = 0;
    private int _hovered = 0;

    [SerializeField] private CircleRenderer _highlightIndicator;

    private void Awake()
    {
        if (gameObject.GetComponentInChildren<MaskHolder>())
        {
           mask = gameObject.GetComponentInChildren<MaskHolder>();
        } 
    }

    private void Update()
    {
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
        if (type == "Clicked") _highlightIndicator.radius = 0.625f;
    }
}
