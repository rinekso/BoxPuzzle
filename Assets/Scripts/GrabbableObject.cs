using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableObject : MonoBehaviour
{
    public PhysicMaterial groundPhysics;
    [SerializeField]
    bool isAround = false;
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            isAround = true;
            GameController.instance.ActiveGrab(true);
            GameController.instance.SetObjectToPlayer(gameObject);
        }
    }
    private void OnTriggerExit(Collider other) {
        if(other.tag == "Player"){
            isAround = false;
            GameController.instance.ActiveGrab(false);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player" && !isAround){
            GetComponent<BoxCollider>().material = groundPhysics;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if(collision.transform.tag == "Player"){
            GetComponent<BoxCollider>().material = groundPhysics;
        }
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
