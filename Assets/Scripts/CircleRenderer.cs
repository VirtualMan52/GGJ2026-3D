using System.Runtime.CompilerServices;
using UnityEngine;

public class CircleRenderer : MonoBehaviour
{
    public int resolution = 30;
    public float width = 0.1f;
    public float radius = 1f;
    [SerializeField] private LineRenderer line;

    // Update is called once per frame
    void Update()
    {
        if (line == null) return;

        Vector3[] positions = new Vector3[resolution + 1];
        for (int i = 0; i < resolution + 1; i++)
        {
            positions[i] = transform.position + ((Quaternion.Euler(0f, 360f / resolution * i, 0f)) * Vector3.forward) * radius;
        }

        line.positionCount = resolution + 1;
        line.SetPositions(positions);
        line.startWidth = width;
        line.endWidth = width;
    }
}
