using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private bool followX;
    [SerializeField] private bool followZ;

    private Vector3 offset;

    private GameObject target = null;

    [SerializeField] private float bobX = 1;
    [SerializeField] private float bobY = 1;
    private Quaternion baseRotation = Quaternion.identity;

    private void Awake()
    {
        baseRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (followX || followZ)
        {
            if (target)
            {
                Vector3 followPosition = new Vector3(followX ? target.transform.position.x : 0f, 0f, followZ ? target.transform.position.z : 0f);

                Camera.main.transform.position = followPosition + offset;
            }
            else
            {
                if (SwapperScript.Singleton && SwapperScript.Singleton.GetSelectedSwappable())
                {
                    target = SwapperScript.Singleton.GetSelectedSwappable().gameObject;
                    offset = Camera.main.transform.position - target.transform.position;
                }
            }
        }
        Quaternion rotated = baseRotation;
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        float x = Mathf.Clamp(((mousePosition.x / Screen.width) - 0.5f) * 2,-1,1);
        float y = Mathf.Clamp(((mousePosition.y / Screen.height) - 0.5f) * -2,-1,1);
        rotated *= Quaternion.Euler(Vector3.up * bobX * x);
        rotated *= Quaternion.Euler(Vector3.right * bobY * y);
        transform.rotation = rotated;
    }
}
