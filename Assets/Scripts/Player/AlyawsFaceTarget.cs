using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlyawsFaceTarget : MonoBehaviour
{
    public GameObject target;
    [SerializeField]
    bool mainCamTarget;
    private void Start() {
        if(mainCamTarget) target = Camera.main.gameObject;
    }
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target.transform);
    }
}
