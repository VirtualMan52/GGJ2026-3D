using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private bool followX;
    [SerializeField] private bool followZ;

    private Vector3 offset;

    private GameObject target = null;

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            Vector3 followPosition = new Vector3(followX ? target.transform.position.x : 0f, 0f, followZ ? target.transform.position.z : 0f);

            Camera.main.transform.position = followPosition + offset;
        } else
        {
            if (SwapperScript.Singleton && SwapperScript.Singleton.heldObject)
            {
                target = SwapperScript.Singleton.heldObject;
                offset = Camera.main.transform.position - target.transform.position;
            }
        }
    }
}
