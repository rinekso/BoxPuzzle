using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotifDetection : MonoBehaviour
{
    public GameController.Interaction interaction;
    public int id;
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            other.GetComponent<PlayerDialogController>().ShowNotif(true, transform.position);
            GameController.instance.currentGOInteraction = gameObject;
            GameController.instance.currentIdInteraction = id;
            GameController.instance.currentTypeInteraction = interaction;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player"){
            other.GetComponent<PlayerDialogController>().ShowNotif(false, transform.position);
        }
    }
}
