using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineStatistic : MonoBehaviour
{
    public Transform[] points;
    [SerializeField]
    bool loopLine = false;
    LineRenderer lineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = points.Length+1;
    }

    // Update is called once per frame
    void Update()
    {
    }
    void SpawnPoint(){
        for (int i = 0; i < points.Length; i++)
        {
            lineRenderer.SetPosition(i,points[i].position);
        }
        lineRenderer.SetPosition(points.Length,points[0].position);
    }
}
