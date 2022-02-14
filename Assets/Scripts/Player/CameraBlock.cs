using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBlock : MonoBehaviour
{
    public float cameraRotateTarget;
    private void OnTriggerStay(Collider other) {
        if(other.tag == "Player"){
            GameObject.Find("CamPlace").GetComponent<RotationCam>().rotation = cameraRotateTarget;
        }
    }
}
