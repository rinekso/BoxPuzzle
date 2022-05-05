using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    private void Update() {
        if(target != null){
            Vector3 desirePosition = target.position + offset;
            Vector3 smoothPosition = Vector3.Lerp(transform.position, desirePosition, smoothSpeed);
            transform.position = smoothPosition;
            // transform.position = target.position+offset;
        }
    }
}
