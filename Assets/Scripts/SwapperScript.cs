using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwapperScript : MonoBehaviour
{
    [SerializeField] private LayerMask _mouseLayers;

    [SerializeField] public GameObject heldObject;

    private bool speedUp = false;

    private static SwapperScript _singleton;
    public static SwapperScript Singleton
    {
        get => _singleton;
        private set
        {
            _singleton = value;
        }
    }
    private void Awake()
    {
        Singleton = this;
    }

    void Update()
    {
        if (!WinConditionScript.Singleton || WinConditionScript.Singleton.levelComplete)
        {
            // If is won, don't do mouse checks and stop speed up
            Time.timeScale = 1;
            return;
        }

        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, _mouseLayers))
        {
            GameObject hitObject = hit.collider.gameObject;
            
            //TODO: Highlight item

            if (heldObject)
            {
                // Someone highlighted...
                if (hitObject.GetComponent<SlotFollowerScript>())
                {
                    SlotFollowerScript hitsf = hitObject.GetComponent<SlotFollowerScript>();

                    bool canSwap = true;

                    // Don't swap with lover!
                    if (hitObject.GetComponent<LoverScript>()) canSwap = false;

                    // Don't swap if too far!
                    if (canSwap && heldObject.GetComponent<SwappableScript>().swapRange + 0.2f < Vector3.Distance(heldObject.transform.position, hitObject.transform.position)) canSwap = false;

                    // Don't swap if it has a mask and you don't!
                    if (canSwap && hitObject.GetComponentInChildren<MaskHolder>())
                    {
                        MaskHolder myMask = heldObject.GetComponentInChildren<MaskHolder>();
                        MaskHolder hitMask = hitObject.GetComponentInChildren<MaskHolder>();

                        if (myMask == null || myMask.maskID != hitMask.maskID) canSwap = false;
                    }

                    if (canSwap) hitObject.GetComponent<SlotFollowerScript>().highlight = 2; // Highlight item if you can swap!
                    if (Mouse.current.leftButton.ReadValue() < 0.1) // On release...
                    {
                        if (canSwap)
                        {
                            Slot hitSlot = hitsf.GetSlot();
                            Slot heldSlot = heldObject.GetComponent<SlotFollowerScript>().GetSlot();

                            hitsf.ChangeSlot(heldSlot);
                            heldObject.GetComponent<SlotFollowerScript>().ChangeSlot(hitSlot);
                        }
                        heldObject = null;
                    }
                } else if (hitObject.GetComponentInChildren<MaskTableScript>()) // Mask table highlighted...
                {
                    MaskTableScript mt = hitObject.GetComponentInChildren<MaskTableScript>();
                    if (mt.mask)
                    {
                        mt.highlight = 2;

                        if (Mouse.current.leftButton.ReadValue() < 0.1) // On release...
                        {
                            MaskHolder heldMask = heldObject.GetComponentInChildren<MaskHolder>();
                            MaskHolder hitMask = mt.mask;

                            mt.mask.transform.SetParent(heldObject.transform,true);
                            if (heldMask)
                            {
                                heldMask.transform.SetParent(mt.transform, true);
                                mt.mask = heldMask;
                            }
                            else mt.mask = null;

                                heldObject = null;
                        }
                    }
                }
                
            } else
            {
                if (hitObject.GetComponent<SlotFollowerScript>() && hitObject.GetComponent<SwappableScript>()) 
                {
                    hitObject.GetComponent<SlotFollowerScript>().highlight = 2;
                    if (Mouse.current.leftButton.ReadValue() > 0) heldObject = hitObject;
                }
            }
        }

        if (heldObject) heldObject.GetComponent<SlotFollowerScript>().highlight = 2;
        if (heldObject && Mouse.current.leftButton.ReadValue() < 0.1) heldObject = null;

        if (speedUp) Time.timeScale = 3;
        else Time.timeScale = 1;
    }

    public void OnSpeedUp(InputValue value)
    {
        Debug.Log(value.isPressed);
        speedUp = value.isPressed;
    }
}
