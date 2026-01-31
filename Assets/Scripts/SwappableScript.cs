using JetBrains.Annotations;
using UnityEngine;

public class SwappableScript : MonoBehaviour
{
    [SerializeField] private CircleRenderer _rangeIndicator;
    public float swapRange;

    public void Start()
    {
        _rangeIndicator.radius = swapRange;
    }
}
