using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadTouch : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        if(other.transform.tag == "Player"){
            GameController.instance.Dead();
        }else if(other.transform.tag != "Ground"){
            if(other.gameObject.GetComponent<PositionReset>())
                other.gameObject.GetComponent<PositionReset>().ResetPosition();
        }
    }
    private void OnCollisionStay(Collision other) {
        
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
