using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce;
    public float dashForce;
    [SerializeField]
    bool jumpable = true;
    bool isJump = false;
    bool jumpPress = false;
    public bool onAir = false;
    public bool canMove = true;
    public bool isDashing = false;
    private Camera camera;
    Rigidbody rigidbody;
    FixedJoystick fixedJoystick;
    public bool joystick;
    float horizontal, vertical;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        camera = Camera.main;
        fixedJoystick = GameObject.FindObjectOfType<FixedJoystick>();
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump")) Jump();

        if(joystick && fixedJoystick){
            horizontal = fixedJoystick.Horizontal;
            vertical = fixedJoystick.Vertical;
            if(horizontal != 0 && vertical != 0)
                Move();
            else
                animator.SetBool("Move",false);
        }else{
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
            if(Input.GetAxisRaw("Vertical") != 0 || Input.GetAxisRaw("Horizontal") != 0)
                Move();
            else
                animator.SetBool("Move",false);
        }
    }
    public void Jump(){
        if(jumpable){
            isJump = true;
            jumpPress = true;
            StartCoroutine(CooldownJump());
            if(onAir == false){
                print("jump");
                onAir = true;
                rigidbody.velocity = Vector3.zero;
                rigidbody.angularVelocity = Vector3.zero;
                rigidbody.velocity = new Vector3(0,jumpForce,0);
            }
        }
    }
    IEnumerator CooldownJump(){
        yield return new WaitForSeconds(.2f);
        jumpPress = false;
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
        animator.SetBool("Move",true);
        animator.SetFloat("Horizontal",horizontal);

        Vector3 input = new Vector3(horizontal,0,vertical);
        Vector3 camPos = camera.transform.position;

        Vector3 a = camPos+input;
        dirTemp = Quaternion.Euler(new Vector3(0,camera.transform.rotation.eulerAngles.y,0))*(a-camPos).normalized;
        if(canMove){
            if(!isJump){
                rigidbody.velocity = new Vector3(dirTemp.x*speed,rigidbody.velocity.y,dirTemp.z*speed);
            }else{
                float dif = 1.7f;
                rigidbody.velocity = new Vector3(dirTemp.x*speed/dif,rigidbody.velocity.y,dirTemp.z*speed/dif);
            }
        }
            // if(distancePass){
            //     if(distance < Vector3.Distance(positionTemp,pointHinge.position)){
            //         positionTemp = transform.position;
            //     }
            // }
            // transform.rotation = Quaternion.LookRotation(dirTemp);
    }
    private void OnCollisionStay(Collision other) {
        if(other.contacts.Length > 0)
        {
            ContactPoint contact = other.contacts[0];
            if(Vector3.Dot(contact.normal, Vector3.up) > 0.5)
            {
                onAir = false;
                if(!jumpPress) isJump = false;
            }
        }
    }
    private void OnCollisionExit(Collision other) {
        onAir = true;
    }
}
