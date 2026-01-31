using UnityEngine;

public class MaskTableScript : MonoBehaviour
{
    public MaskHolder mask;
    public int highlight = 0;

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
            if (highlight > 0)
            {
                highlight--;
                _highlightIndicator.radius = Mathf.Lerp(_highlightIndicator.radius, 0.5f, 0.125f);
            }
            else _highlightIndicator.radius = Mathf.Lerp(_highlightIndicator.radius, 0f, 0.125f);
        }
    }
}
