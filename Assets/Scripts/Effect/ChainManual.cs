using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainManual : MonoBehaviour
{
    public Transform firstPoint;
    public Transform secondPoint;
    LineRenderer lineRenderer;
    [SerializeField]
    int pointCount = 3;
    [SerializeField]
    float distance;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = pointCount;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(firstPoint.position,secondPoint.position);
        SpawnPoint();
    }
    void SpawnPoint(){
        float amp = 0;
        if(distance <= 5){
            amp = 30;
        }else if(distance > 5 && distance < 10){
            amp = distance*6;
        }else{
            amp = 60;
        }
        for (int i = 0; i < pointCount; i++)
        {
            float t = ((float)i/(pointCount-1));
            Vector3 posTemp = Vector3.Lerp(firstPoint.position,secondPoint.position,t);
            posTemp.y = (Mathf.Pow(i,2)-9*i)/amp;
            lineRenderer.SetPosition(i,posTemp);
        }
    }
}
