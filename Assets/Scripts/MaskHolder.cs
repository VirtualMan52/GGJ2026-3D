using UnityEngine;

public class MaskHolder : MonoBehaviour
{
    public string maskID;
    public Color gizmoColor;

    private void Update()
    {
        if (transform.localPosition != Vector3.zero)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, Vector3.zero, 0.125f);
        }
    }
}
