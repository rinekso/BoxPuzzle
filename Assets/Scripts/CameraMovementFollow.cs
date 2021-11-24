using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementFollow : MonoBehaviour
{
    GameObject currentPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 screenPoint = GetComponent<Camera>().WorldToViewportPoint(GameController.instance.currentPlayer.transform.position);
        bool onScreen = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;
        
    }
}
