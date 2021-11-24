using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce;
    public float dashForce;
    public bool onAir = false;
    public bool canMove = true;
    public bool isDashing = false;
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
        if(Input.GetButtonDown("Jump")) Jump();
    }
    public void Jump(){
        if(onAir == false){
            onAir = true;
            rigidbody.AddForce(Vector3.up*jumpForce);
        }
    }
    public void Dash(){
        if(isDashing == false)
            StartCoroutine(DashTime());
    }
    Vector3 dirTemp;
    IEnumerator DashTime(){
        canMove = false;
        isDashing = true;
        
        rigidbody.velocity = new Vector3(dirTemp.x*dashForce,0,dirTemp.z*dashForce);
        yield return new WaitForSeconds(.5f);
        canMove = true;
        yield return new WaitForSeconds(.5f);
        isDashing = false;
    }
    void Move(){
        Vector3 input = new Vector3(horizontal,0,vertical);
        Vector3 camPos = camera.transform.position;

        Vector3 a = camPos+input;
        dirTemp = Quaternion.Euler(new Vector3(0,camera.transform.rotation.eulerAngles.y,0))*(a-camPos).normalized;
        if(canMove){
            rigidbody.velocity = new Vector3(dirTemp.x*speed,rigidbody.velocity.y,dirTemp.z*speed);
            transform.rotation = Quaternion.LookRotation(dirTemp);
        }
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
