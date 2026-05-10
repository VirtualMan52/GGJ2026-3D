using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEditor.PlayerSettings;

public class DanceFloorScript : MonoBehaviour
{
    [SerializeField] private int _sizeX;
    [SerializeField] private int _sizeZ;

    [SerializeField] GameObject defaultGO;
    [SerializeField] GameObject defaultMask;

    // have editor react
    private void OnValidate()
    {
        SetSlots();
        UpdateFlooring();
    }

    public Slot[] _slots = new Slot[0];
    //[SerializeField] private Transform flooring;
    
    public void Awake()
    {
        SetSlots();
        for (int i = 0; i < _slots.Length; i++)
        {
            Slot s = _slots[i];
            s.collection = gameObject;
            s.Initialize();
        }

        UpdateFlooring();
    }

    // Update is called once per frame
    void Update()
    {
        SetSlots();
    }

    private void SetSlots()
    {
        if (_slots.Length != _sizeX*_sizeZ) _slots = new Slot[_sizeX * _sizeZ];
        for (int x = 0; x < _sizeX; x++)
        {
            for (int z = 0; z < _sizeZ; z++)
            {
                int index = x * _sizeZ + z;
                if (_slots[index] == null)
                {
                    _slots[index] = new Slot();
                    if (defaultGO) _slots[index].beginWith = defaultGO;
                    if (defaultMask) _slots[index].beginMask = defaultMask;
                }
                _slots[index].pos = gameObject.transform.position - new Vector3(1.25f * (_sizeX - 1), 0, 1.25f * (_sizeZ - 1)) + new Vector3(2.5f * x, 0, 2.5f * z);
            }
        }
    }

    private void UpdateFlooring()
    {
        return;
    }

    private void OnDrawGizmos()
    {
        for (int i = 0; i < _slots.Length; i++)
        {
            Slot s = _slots[i];
            Vector3 pos = s.pos;

            Gizmos.color = Color.white;
            //if (_slots[i].beginMask)
            //{
            //    Gizmos.color = _slots[i].beginMask.GetComponent<MaskHolder>().gizmoColor;
            //}

            Gizmos.DrawSphere(pos, 0.5f);
        }
    }

    private void OnDrawGizmosSelected()
    {
        SetSlots();
    }
}
