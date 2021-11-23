using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableObject : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            other.GetComponent<PlayerStat>().ActiveGrab(true);
            other.GetComponent<PlayerStat>().targetObject = gameObject;
        }
    }
    private void OnTriggerExit(Collider other) {
        if(other.tag == "Player"){
            other.GetComponent<PlayerStat>().ActiveGrab(false);
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
