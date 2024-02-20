using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BSpline : MonoBehaviour
{
    //This script creates a BSpline, using 7 Transforms added in the Editor and adds the points to be drawn to 4 LineRenderers
    [Header("Point References")] public Transform p0;

    public Transform p1,p2,p3,p4,p5,p6;
    public LineRenderer lineRenderer0, lineRenderer1, lineRenderer2, lineRenderer3;

    [Range(1,50)] public int numberOfLineSegments = 30;

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
        Vector3 p5Position = p6.position;
        Vector3 p6Position = p5.position;
        
        //Increment Value for t
        float incrementValue = 1f / numberOfLineSegments;
        float t = 0;
        //Calculate Weights
        //Segment 1
        Vector3 a0 = -1 * p0Position + 3f *  p1Position - 3f * p2Position + 1f * p3Position;
        Vector3 b0 = 3f * p0Position - 6f * p1Position + 3f * p2Position + 0f * p3Position;
        Vector3 c0 = -3f * p0Position + 0f * p1Position + 3f * p2Position + 0f * p3Position;
        Vector3 d0 = 1f * p0Position + 4f * p1Position + 1f * p2Position + 0f * p3Position;
        a0 /= 6f;
        b0 /= 6f;
        c0 /= 6f;
        d0 /= 6f;
        //Segment 2
        Vector3 a1 = -1 * p1Position + 3f *  p2Position - 3f * p3Position + 1f * p4Position;
        Vector3 b1 = 3f * p1Position - 6f * p2Position + 3f * p3Position + 0f * p4Position;
        Vector3 c1 = -3f * p1Position + 0f * p2Position + 3f * p3Position + 0f * p4Position;
        Vector3 d1 = 1f * p1Position + 4f * p2Position + 1f * p3Position + 0f * p4Position;
        a1 /= 6f;
        b1 /= 6f;
        c1 /= 6f;
        d1 /= 6f;
        //Segment 3
        Vector3 a2 = -1 * p2Position + 3f *  p3Position - 3f * p4Position + 1f * p5Position;
        Vector3 b2 = 3f * p2Position - 6f * p3Position + 3f * p4Position + 0f * p5Position;
        Vector3 c2 = -3f * p2Position + 0f * p3Position + 3f * p4Position + 0f * p5Position;
        Vector3 d2 = 1f * p2Position + 4f * p3Position + 1f * p4Position + 0f * p5Position;
        a2 /= 6f;
        b2 /= 6f;
        c2 /= 6f;
        d2 /= 6f;
        //Segment 4
        Vector3 a3 = -1 * p3Position + 3f *  p4Position - 3f * p5Position + 1f * p6Position;
        Vector3 b3 = 3f * p3Position - 6f * p4Position + 3f * p5Position + 0f * p6Position;
        Vector3 c3 = -3f * p3Position + 0f * p4Position + 3f * p5Position + 0f * p6Position;
        Vector3 d3 = 1f * p3Position + 4f * p4Position + 1f * p5Position + 0f * p6Position;
        a3 /= 6f;
        b3 /= 6f;
        c3 /= 6f;
        d3 /= 6f;

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
