using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionReset : MonoBehaviour
{
    Vector3 positionStart;
    // Start is called before the first frame update
    void Start()
    {
        positionStart = transform.position;
    }
    public void ResetPosition(){
        transform.position = positionStart;
        transform.parent = null;
    }
}
