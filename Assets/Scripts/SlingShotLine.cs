using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(LineRenderer))]
public class SlingShotLine : MonoBehaviour
{
    [Header("Rope Settings")]
    [SerializeField] private Transform Point1;
    [SerializeField] private Transform Point2;

    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        if (Point1 && Point2)
        {
            lineRenderer.positionCount = 2;
            lineRenderer.SetPosition(0, Point1.position);
            lineRenderer.SetPosition(1, Point2.position);
        }
    }
}
