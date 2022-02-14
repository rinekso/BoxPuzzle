using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            JumpLevel(transform.parent.GetComponent<GateScript>().level);
        }
    }
    void JumpLevel(int index){
        GameController.instance.JumpLevel(index);
    }
}
