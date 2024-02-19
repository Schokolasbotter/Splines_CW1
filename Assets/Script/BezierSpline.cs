using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierSpline : MonoBehaviour
{
    //This script creates a Bezier Spline
    [Header("Point References")] public Transform p0;

    public Transform p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12;

    public LineRenderer lineRenderer0, lineRenderer1, lineRenderer2, lineRenderer3;

    [Range(1,50)] public int numberOfLineSegments = 30;
    public float tValue = 0f;

    private List<Vector3> _segment0Points,_segment1Points, _segment2Points, _segment3Points;
    // Update is called once per frame
    void Update()
    {
        //Setup LineRenderers
        lineRenderer0.positionCount = numberOfLineSegments + 1;
        lineRenderer1.positionCount = numberOfLineSegments + 1;
        lineRenderer2.positionCount = numberOfLineSegments + 1;
        lineRenderer3.positionCount = numberOfLineSegments + 1;
        //Prepare Lists
        _segment0Points = new List<Vector3>();
        _segment1Points = new List<Vector3>();
        _segment2Points = new List<Vector3>();
        _segment3Points = new List<Vector3>();
        //Read Positions;
        Vector3 p0Position = p0.position;
        Vector3 p1Position = p1.position;
        Vector3 p2Position = p2.position;
        Vector3 p3Position = p3.position;
        Vector3 p4Position = p4.position;
        Vector3 p5Position = p5.position;
        Vector3 p6Position = p6.position;
        Vector3 p7Position = p7.position;
        Vector3 p8Position = p8.position;
        Vector3 p9Position = p9.position;
        Vector3 p10Position = p10.position;
        Vector3 p11Position = p11.position;
        Vector3 p12Position = p12.position;
        
        //Increment Value for t
        float incrementValue = 1f / numberOfLineSegments;
        float t = 0;
        //Calculate Weights
        //Segment 1
        Vector3 a0 = -p0Position + 3f * p1Position - 3f * p2Position + p3Position;
        Vector3 b0 = 3f * p0Position - 6f * p1Position + 3f * p2Position;
        Vector3 c0 = -3f * p0Position + 3f * p1Position;
        Vector3 d0 = p0Position;
        //Segment 2
        Vector3 a1 = -p3Position + 3f * p4Position - 3f * p5Position + p6Position;
        Vector3 b1 = 3f * p3Position - 6f * p4Position + 3f * p5Position;
        Vector3 c1 = -3f * p3Position + 3f * p4Position;
        Vector3 d1 = p3Position;
        //Segment 3
        Vector3 a2 = -p6Position + 3f * p7Position - 3f * p8Position + p9Position;
        Vector3 b2 = 3f * p6Position - 6f * p7Position + 3f * p8Position;
        Vector3 c2 = -3f * p6Position + 3f * p7Position;
        Vector3 d2 = p6Position;
        //Segment 4
        Vector3 a3 = -p9Position + 3f * p10Position - 3f * p11Position + p12Position;
        Vector3 b3 = 3f * p9Position - 6f * p10Position + 3f * p11Position;
        Vector3 c3 = -3f * p9Position + 3f * p10Position;
        Vector3 d3 = p9Position;

        for (int i = 0; i <= numberOfLineSegments; i++)
        {
            //Calculate Points on Curves
            Vector3 pointOnSegment0 = a0 * Mathf.Pow(t, 3) + b0 * Mathf.Pow(t, 2) + c0 * t + d0;
            Vector3 pointOnSegment1 = a1 * Mathf.Pow(t, 3) + b1 * Mathf.Pow(t, 2) + c1 * t + d1;
            Vector3 pointOnSegment2 = a2 * Mathf.Pow(t, 3) + b2 * Mathf.Pow(t, 2) + c2 * t + d2;
            Vector3 pointOnSegment3 = a3 * Mathf.Pow(t, 3) + b3 * Mathf.Pow(t, 2) + c3 * t + d3; 
            //Add points to lists;
            _segment0Points.Add(pointOnSegment0);
            _segment1Points.Add(pointOnSegment1);
            _segment2Points.Add(pointOnSegment2);
            _segment3Points.Add(pointOnSegment3);
            //increment t
            t += incrementValue;
        }
        
        //Apply to LineRenderer
        lineRenderer0.SetPositions(_segment0Points.ToArray());
        lineRenderer1.SetPositions(_segment1Points.ToArray());
        lineRenderer2.SetPositions(_segment2Points.ToArray());
        lineRenderer3.SetPositions(_segment3Points.ToArray());
    }
    
}
