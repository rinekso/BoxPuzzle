using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    PlayerMovment playerMovment;
    void Start()
    {
        playerMovment = transform.parent.GetComponent<PlayerMovment>();
    }
    private void OnTriggerStay(Collider other){
        playerMovment.onAir = false;
    }
    private void OnTriggerExit(Collider other)
    {
        playerMovment.onAir = true;
    }
}
