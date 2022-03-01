using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rinekso.Interface;

public class ButtonEnv : MonoBehaviour
{
    [SerializeField]
    public GameObject platformTarget;
    [SerializeField]
    bool isActive = false;
    GameObject currentObject;
    private void OnTriggerStay(Collider other) {
        if(!isActive){
            currentObject = other.gameObject;
            GetComponent<Animator>().SetBool("active",true);
            platformTarget.GetComponent<IPlatformInterface>().OnActive();
            GameObject.FindObjectOfType<RotationCam>().GetFar();
            isActive = true;
        }
    }
    private void OnTriggerExit(Collider other) {
        if(isActive && other.gameObject == currentObject){
            GetComponent<Animator>().SetBool("active",false);
            platformTarget.GetComponent<IPlatformInterface>().OnDeactive();
            GameObject.FindObjectOfType<RotationCam>().GetClose();
            isActive = false;
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
