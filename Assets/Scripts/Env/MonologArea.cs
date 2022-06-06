using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonologArea : MonoBehaviour
{
    public string area;
    public bool repeat=true;
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Monolog"){
            other.GetComponent<MainPlayerScript>().StartMonolog(area,repeat);
        }
    }
    private void OnTriggerExit(Collider other) {
        if(other.tag == "Monolog"){
            other.GetComponent<MainPlayerScript>().StopMonolog();
        }
    }
}
