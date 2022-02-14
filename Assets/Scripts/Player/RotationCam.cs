using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationCam : MonoBehaviour
{
    public float rotation = 0;
    public float smoothSpeed;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0,rotation,0), smoothSpeed);
    }
}
