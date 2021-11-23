using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadTouch : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        if(other.transform.tag == "Player"){
            GameController.instance.Dead();
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
