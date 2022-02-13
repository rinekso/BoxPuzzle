using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.transform.tag == "Player"){
            Teleport();
        }
    }
    void Teleport(){
        print("teleport");
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
