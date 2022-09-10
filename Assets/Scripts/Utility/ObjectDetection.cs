using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectDetection : MonoBehaviour
{
    public string targetTag;
    public GameObject objectDetectionEvent;
    public UnityEvent triggerEnter;
    public UnityEvent triggerExit;
    public UnityEvent triggerStay;
    bool enter = false;
    
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Triggerer" && !enter){
            if(targetTag != "")
                if(other.GetComponent<TriggererProperty>().name != targetTag)
                    return;
            enter = true;
            if(triggerEnter != null) triggerEnter.Invoke();
            if(objectDetectionEvent) objectDetectionEvent.GetComponent<IObjectDetectionEvent>().TriggerEnter(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other) {
        if(other.tag == "Triggerer"){
            if(targetTag != "")
                if(other.GetComponent<TriggererProperty>().name != targetTag)
                    return;
            if(triggerExit != null) triggerExit.Invoke();
            if(objectDetectionEvent) objectDetectionEvent.GetComponent<IObjectDetectionEvent>().TriggerExit(other.gameObject);
        }
    }
    private void OnTriggerStay(Collider other) {
        if(other.tag == "Triggerer"){
            if(targetTag != "")
                if(other.GetComponent<TriggererProperty>().name != targetTag)
                    return;
            enter = false;
            if(triggerStay != null) triggerStay.Invoke();
            if(objectDetectionEvent) objectDetectionEvent.GetComponent<IObjectDetectionEvent>().TriggerStay(other.gameObject);
        }
    }

}
