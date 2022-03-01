using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationCam : MonoBehaviour
{
    public float rotation = 0;
    public float smoothSpeed;
    [SerializeField]
    Transform pointClose;
    [SerializeField]
    Transform pointFar;
    [SerializeField]
    float durationMove = 1;
    GameObject camChild;
    private void Start() {
        camChild = GetComponentInChildren<Camera>().gameObject;
    }
    public void GetClose(){
        StopAllCoroutines();
        GetComponentInChildren<Camera>().farClipPlane = 50;
        print("close");
        StartCoroutine(Move(camChild.transform.localPosition,pointClose.localPosition,durationMove));
    }
    public void GetFar(){
        StopAllCoroutines();
        GetComponentInChildren<Camera>().farClipPlane = 100;
        print("far");
        StartCoroutine(Move(camChild.transform.localPosition,pointFar.localPosition,durationMove));
    }
    IEnumerator Move(Vector3 posStart, Vector3 posEnd, float duration){
        float t = 0;
        while(t<1){
            yield return null;
            t += Time.deltaTime/duration;
            camChild.transform.localPosition = Vector3.Lerp(posStart,posEnd,t);
        }
        t = 1;
        camChild.transform.localPosition = posEnd;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0,rotation,0), smoothSpeed);
    }
}
