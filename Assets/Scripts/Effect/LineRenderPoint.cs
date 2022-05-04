using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRenderPoint : MonoBehaviour
{
    public LineRenderer line;
    public Transform[] positions;
    // Start is called before the first frame update
    void Start()
    {
        line.positionCount = positions.Length;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < line.positionCount; i++)
        {
            line.SetPosition(i, positions[i].position);            
        }
    }
}
