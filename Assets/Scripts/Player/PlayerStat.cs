using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    public GameObject targetObject;
    public Transform objectTemp;
    public Transform placingObject;
    public bool isFrontEmpty = true;
    public void GrabObject(){
        targetObject.transform.parent = objectTemp;
        targetObject.transform.localPosition = Vector3.zero;
        targetObject.transform.localRotation = new Quaternion();
        targetObject.GetComponent<Rigidbody>().mass = 0;
        targetObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }
    public void DropObject(){
        if(isFrontEmpty){
            objectTemp.GetChild(0).position = placingObject.position;
            objectTemp.GetChild(0).parent = transform.parent;
            targetObject.GetComponent<Rigidbody>().mass = 5;
            targetObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        }
    }
}
