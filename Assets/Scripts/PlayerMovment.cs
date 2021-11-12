using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public float speed = 10f;
    private Camera camera;
    Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        camera = Camera.main;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0){
            Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"),0,Input.GetAxisRaw("Vertical"));
            Vector3 camPos = camera.transform.position;

            Vector3 a = camPos+input;
            Vector3 dir = Quaternion.Euler(new Vector3(0,camera.transform.rotation.eulerAngles.y,0))*(a-camPos).normalized;
            rigidbody.velocity = dir*speed;
        }else{
            rigidbody.velocity = Vector3.zero;
        }
    }
}
