using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce;
    bool onAir = false;
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
            Vector3 input = new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
            Vector3 camPos = camera.transform.position;

            Vector3 a = camPos+input;
            Vector3 dir = Quaternion.Euler(new Vector3(0,camera.transform.rotation.eulerAngles.y,0))*(a-camPos).normalized;
            rigidbody.velocity = new Vector3(dir.x*speed,rigidbody.velocity.y,dir.z*speed);
            transform.rotation = Quaternion.LookRotation(dir);
        }else{
            rigidbody.velocity = new Vector3(0,rigidbody.velocity.y,0);;
        }
        if(Input.GetButtonDown("Jump") && onAir == false){
            print("jump");
            onAir = true;
            rigidbody.AddForce(Vector3.up*jumpForce);
        }
    }
    private void OnCollisionStay(Collision other) {
        if(other.transform.tag == "Ground")
        onAir = false;
    }
}
