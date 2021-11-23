using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlok : MonoBehaviour
{
    public Transform[] points;
    public float duration;
    int currentPoint = 0;
    private void Start() {
        StartCoroutine(Move());
    }
    private void OnTriggerEnter(Collider other) {
        if(other.transform.tag == "Player"){
            other.transform.parent = transform;
        }
    }
    private void OnTriggerExit(Collider other) {
        if(other.transform.tag == "Player"){
            other.transform.parent = null;
        }
    }
    IEnumerator Move(){
        int targetPoint = currentPoint+1;
        if(currentPoint+1 == points.Length){
            targetPoint = 0;
        }
        float t = 0;
        while (t < 1)
        {
            yield return null;
            t += Time.deltaTime/duration;
            transform.position = Vector3.Lerp(points[currentPoint].position,points[targetPoint].position,t);
        }
        transform.position = points[targetPoint].position;
        if(currentPoint+1 == points.Length){
            currentPoint = 0;
        }else{
            currentPoint++;
        }
        yield return Move();
    }
}
