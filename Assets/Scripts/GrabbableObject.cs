using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableObject : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            GameController.instance.ActiveGrab(true);
            GameController.instance.SetObjectToPlayer(gameObject);
        }
    }
    private void OnTriggerExit(Collider other) {
        if(other.tag == "Player"){
            GameController.instance.ActiveGrab(false);
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
