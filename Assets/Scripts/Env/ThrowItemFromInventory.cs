using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowItemFromInventory : MonoBehaviour
{
    [SerializeField]
    float force = 2;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.up*force,ForceMode.Force);
    }
    private void OnCollisionEnter(Collision other) {
        if (other.transform.tag == "Ground")
        {
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<Collider>().isTrigger = true;
        }
    }
}
