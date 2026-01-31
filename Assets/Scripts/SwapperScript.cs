using UnityEngine;
using UnityEngine.InputSystem;

public class SwapperScript : MonoBehaviour
{
    [SerializeField] private LayerMask _mouseLayers;

    [SerializeField] private GameObject _heldObject;

    void Update()
    {
        Debug.Log(_heldObject);


        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, _mouseLayers))
        {
            GameObject hitObject = hit.collider.gameObject;
            
            //TODO: Highlight item

            if (_heldObject)
            {
                if (Mouse.current.leftButton.ReadValue() < 0.1)
                {
                    if (hitObject.GetComponent<SlotFollowerScript>())
                    {
                        bool canSwap = true;

                        // Don't swap if too far!
                        if (_heldObject.GetComponent<SwappableScript>().swapRange < Vector3.Distance(_heldObject.transform.position,hitObject.transform.position)) canSwap = false;

                        if (canSwap)
                        {
                            Slot hitSlot = hitObject.GetComponent<SlotFollowerScript>().GetSlot();
                            Slot heldSlot = _heldObject.GetComponent<SlotFollowerScript>().GetSlot();

                            hitObject.GetComponent<SlotFollowerScript>().ChangeSlot(heldSlot);
                            _heldObject.GetComponent<SlotFollowerScript>().ChangeSlot(hitSlot);
                        }
                    }

                    _heldObject = null;
                }
            } else
            {
                if (hitObject.GetComponent<SlotFollowerScript>() && hitObject.GetComponent<SwappableScript>() && Mouse.current.leftButton.ReadValue() > 0)
                {
                    _heldObject = hitObject;
                }
            }
        }

        if (_heldObject && Mouse.current.leftButton.ReadValue() < 0.1)
        {
            _heldObject = null;
        }
    }
}
