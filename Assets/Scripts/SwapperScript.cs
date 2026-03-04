using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using System.Net;

public class SwapperScript : MonoBehaviour
{
    [SerializeField] private LayerMask _mouseLayers;

    private bool speedUp = false;
    private bool mouseHeld = false;
    private bool mouseClick = false;

    private static List<SwappableScript> swappables = new List<SwappableScript>();

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
        swappables.Clear();
    }

    void Update()
    {
        if (!WinConditionScript.Singleton || WinConditionScript.Singleton.levelComplete)
        {
            // If is won, don't do mouse checks and stop speed up
            Time.timeScale = 1;
            return;
        }

        if (Mouse.current.leftButton.ReadValue() > 0)
        {
            mouseClick = !mouseHeld;
            mouseHeld = true;
        } else
        {
            mouseHeld = false;
        }

        // Mouse check
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, _mouseLayers, QueryTriggerInteraction.Ignore))
        {
            GameObject other = hit.collider.gameObject;

            List<SwappableScript> canReach = new List<SwappableScript>();
            foreach (SwappableScript s in swappables)
            {
                if (s.reachable.Contains(other)) canReach.Add(s);
            }

            if (canReach.Count > 0)
            {
                // TODO: currently selected is priority
                SwappableScript me = canReach[0];

                other.SendMessage("Highlighted", "Hovered");

                if (mouseClick)
                {
                    other.SendMessage("Highlighted", "Clicked");
                    
                    if (other.GetComponent<MaskTableScript>())
                    {
                        // Swap with table!
                        MaskTableScript mt = other.GetComponent<MaskTableScript>();
                        MaskHolder hitMask = mt.mask;
                        MaskHolder myMask = me.GetComponentInChildren<MaskHolder>();

                        if (hitMask)
                        {
                            hitMask.transform.SetParent(me.transform, true);
                        }

                        if (myMask)
                        {
                            myMask.transform.SetParent(mt.transform, true);
                            mt.mask = myMask;
                        }
                        else mt.mask = null;

                    } else if (other.GetComponent<SlotFollowerScript>())
                    {
                        // Check for swapping!
                        bool canSwap = true;
                        SlotFollowerScript hitsf = other.GetComponent<SlotFollowerScript>();

                        if (!hitsf.swappable) canSwap = false;

                        if (other.GetComponentInChildren<MaskHolder>()) { // If they have a mask...
                            if(!me.GetComponentInChildren<MaskHolder>() || // You don't have a mask OR
                            other.GetComponentInChildren<MaskHolder>().maskID != me.GetComponentInChildren<MaskHolder>().maskID) // This mask and yours aren't the same...
                                canSwap = false; // Don't swap
                        } 

                        if (canSwap)
                        {
                            // Swap !
                            SlotFollowerScript mysf = me.GetComponent<SlotFollowerScript>();

                            Slot hitSlot = hitsf.GetSlot();
                            Slot mySlot = mysf.GetSlot();

                            hitsf.ChangeSlot(mySlot);
                            mysf.ChangeSlot(hitSlot);
                        }
                    }
                }
            }
        }

        if (speedUp) Time.timeScale = 3;
        else Time.timeScale = 1;
    }

    public void OnSpeedUp(InputValue value)
    {
        speedUp = value.isPressed;
    }

    public void AddSwappable(SwappableScript script)
    {
        swappables.Add(script);
    }

    public SwappableScript GetSelectedSwappable()
    {
        // TODO!!!!!
        return swappables[0];
    }
}
