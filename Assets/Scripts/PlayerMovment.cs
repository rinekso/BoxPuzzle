using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce;
    public bool onAir = false;
    private Camera camera;
    Rigidbody rigidbody;
    FixedJoystick fixedJoystick;
    public bool joystick;
    float horizontal, vertical;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        camera = Camera.main;
        fixedJoystick = GameObject.FindObjectOfType<FixedJoystick>();
    }
    public bool jumpIndicator = false;
    // Update is called once per frame
    void Update()
    {
        if(joystick && fixedJoystick){
            horizontal = fixedJoystick.Horizontal;
            vertical = fixedJoystick.Vertical;
            if(horizontal != 0 && vertical != 0)
                Move();
        }else{
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
            if(Input.GetAxisRaw("Vertical") != 0 || Input.GetAxisRaw("Horizontal") != 0)
                Move();
        }

        if(Input.GetButtonDown("Jump") && onAir == false){
            onAir = true;
            rigidbody.AddForce(Vector3.up*jumpForce);
        }
    }
    void Move(){
        Vector3 input = new Vector3(horizontal,0,vertical);
        Vector3 camPos = camera.transform.position;

        Vector3 a = camPos+input;
        Vector3 dir = Quaternion.Euler(new Vector3(0,camera.transform.rotation.eulerAngles.y,0))*(a-camPos).normalized;
        rigidbody.velocity = new Vector3(dir.x*speed,rigidbody.velocity.y,dir.z*speed);
        transform.rotation = Quaternion.LookRotation(dir);
    }
    private void OnCollisionStay(Collision other) {
        if(other.transform.tag == "Ground")
            onAir = false;
    }
    private void OnCollisionExit(Collision other) {
        if(other.transform.tag == "Ground")
            onAir = true;
    }
}
