using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxRockScript : MonoBehaviour
{
    [SerializeField]
    GameObject target;
    [SerializeField]
    GameObject reverseTarget;
    [SerializeField]
    float reverseAmount = -1.5f;
    Vector3 startReverseTarget;
    Vector3 startTarget;
    private void Start() {
        startTarget = target.transform.position;
        startReverseTarget = reverseTarget.transform.position;
    }
    private void Update() {
        target.transform.position = startTarget-((startReverseTarget-reverseTarget.transform.position)*reverseAmount);
    }
}
