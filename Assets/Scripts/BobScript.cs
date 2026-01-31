using Unity.VisualScripting;
using UnityEngine;

public class BobScript : MonoBehaviour
{
    private Vector3 basePosition;
    private Quaternion baseRotation;

    private float hoverSpeed;
    private float rotateSpeed;

    void Start()
    {
        basePosition = transform.localPosition;
        baseRotation = transform.localRotation;

        hoverSpeed = Random.Range(3, 8);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = basePosition + new Vector3(0,Mathf.Sin(Time.time * hoverSpeed) * 0.075f,0);
    }
}
