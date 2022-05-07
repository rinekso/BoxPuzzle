using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotifDetection : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            other.GetComponent<PlayerDialogController>().ShowNotif(true);
        }        
    }
    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player"){
            other.GetComponent<PlayerDialogController>().ShowNotif(false);
        }
    }
}
