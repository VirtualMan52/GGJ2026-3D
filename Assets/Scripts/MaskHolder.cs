using UnityEngine;

public class MaskHolder : MonoBehaviour
{
    public bool Stealable = false;
    public string maskID;

    private void Update()
    {
        if (transform.localPosition != Vector3.zero)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, transform.localPosition, Time.deltaTime * 0);
        }
    }
}
