using UnityEngine;
using UnityEngine.InputSystem;

public class SwapperScript : MonoBehaviour
{
    [SerializeField] private LayerMask _mouseLayers;

    [SerializeField] private GameObject _heldObject;

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, _mouseLayers))
        {
            GameObject hitObject = hit.collider.gameObject;
            
            //TODO: Highlight item

            if (_heldObject)
            {
                bool canSwap = true;

                // Can you swap?
                if (!hitObject.GetComponent<SlotFollowerScript>()) canSwap = false;

                // Don't swap if too far!
                if (canSwap && _heldObject.GetComponent<SwappableScript>().swapRange < Vector3.Distance(_heldObject.transform.position,hitObject.transform.position)) canSwap = false;

                if (canSwap) hitObject.GetComponent<SlotFollowerScript>().highlight = 2; // Highlight item if you can swap!
                if (Mouse.current.leftButton.ReadValue() < 0.1) // On release...
                {
                    if (canSwap)
                    {
                        Slot hitSlot = hitObject.GetComponent<SlotFollowerScript>().GetSlot();
                        Slot heldSlot = _heldObject.GetComponent<SlotFollowerScript>().GetSlot();

                        hitObject.GetComponent<SlotFollowerScript>().ChangeSlot(heldSlot);
                        _heldObject.GetComponent<SlotFollowerScript>().ChangeSlot(hitSlot);
                    }
                    _heldObject = null;
                }
            } else
            {
                if (hitObject.GetComponent<SlotFollowerScript>() && hitObject.GetComponent<SwappableScript>()) 
                {
                    hitObject.GetComponent<SlotFollowerScript>().highlight = 2;
                    if (Mouse.current.leftButton.ReadValue() > 0) _heldObject = hitObject;
                }
            }
        }

        if (_heldObject) _heldObject.GetComponent<SlotFollowerScript>().highlight = 2;
        if (_heldObject && Mouse.current.leftButton.ReadValue() < 0.1) _heldObject = null;
    }
}
