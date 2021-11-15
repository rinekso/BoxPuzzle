using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableBoxScript : MonoBehaviour
{
    private void OnTriggerStay(Collider other) {
        if(other.tag == "Player"){
            print("Pick Up!");
        }
    }
}
