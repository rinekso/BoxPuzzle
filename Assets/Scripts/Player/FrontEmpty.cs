using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontEmpty : MonoBehaviour
{
    void OnTriggerStay(Collider other)
    {
        transform.parent.GetComponent<PlayerStat>().isFrontEmpty = false;
    }
    void OnTriggerExit(Collider other)
    {
        transform.parent.GetComponent<PlayerStat>().isFrontEmpty = true;
    }
}
