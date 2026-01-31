using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class RingScript : MonoBehaviour
{
    [SerializeField] private float _radius = 3;
    [SerializeField] private float _angleOffset = 0;
    [SerializeField] private float _rotationSpeed = 30;
    private float _currentOffset;

    public Slot[] _slots = new Slot[0];

    public void Awake()
    {
        SetSlots();
        for (int i = 0; i < _slots.Length; i++)
        {
            Slot s = _slots[i];
            s.Initialize();
        }
    }

    // Update is called once per frame
    void Update()
    {
        _currentOffset += Time.deltaTime * _rotationSpeed;
        SetSlots();
    }

    private void SetSlots()
    {
        for (int i = 0; i < _slots.Length; i++)
        {
            Slot s = _slots[i];
            s.pos = transform.position + ((Quaternion.Euler(0f, 360f / _slots.Length * i + _currentOffset + _angleOffset, 0f)) * Vector3.forward) * _radius;
        }
    }

    private void OnDrawGizmos()
    {
        for (int i = 0; i < _slots.Length; i++)
        {
            Vector3 pos = transform.position + ((Quaternion.Euler(0f, 360f / _slots.Length * i + _currentOffset + _angleOffset, 0f)) * Vector3.forward) * _radius;

            Gizmos.color = Color.white;
            if (_slots[i].beginMask)
            {
                Gizmos.color = _slots[i].beginMask.GetComponent<MaskHolder>().gizmoColor;
            }
            
            Gizmos.DrawSphere(pos, 0.5f);
        }
    }
}
