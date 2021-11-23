using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    public GameObject grabButton;
    public GameObject targetObject;
    public Transform objectTemp;
    public Transform placingObject;
    public void ObjectPlace(){
        targetObject.transform.parent = objectTemp;
        targetObject.transform.localPosition = Vector3.zero;
        targetObject.transform.localRotation = new Quaternion();
        targetObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }
    public void DropObject(){
        objectTemp.GetChild(0).position = placingObject.position;
        objectTemp.GetChild(0).parent = null;
        targetObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }
    
    public void ActiveGrab(bool stat){
        grabButton.SetActive(stat);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
