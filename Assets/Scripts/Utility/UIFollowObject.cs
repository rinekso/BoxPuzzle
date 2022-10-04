using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFollowObject : MonoBehaviour
{
    public GameObject target;
    Camera mCamera;
    // Start is called before the first frame update
    void Start()
    {
        mCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        var screenPos = mCamera.WorldToScreenPoint(target.transform.position);
        transform.position = screenPos;
    }
}
