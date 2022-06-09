using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerArea : MonoBehaviour
{
    public List<GameObject> triggers;
    private void OnTriggerEnter(Collider other) {
        // print(other.tag);
        if(other.tag == "Triggerer" && !triggers.Contains(other.gameObject)){
            triggers.Add(other.gameObject);
            if(other.TryGetComponent<ITriggerer>(out ITriggerer triggerer)) triggerer.Reaction(); 
        }
    }
    private void OnTriggerExit(Collider other) {
        if(other.tag == "Triggerer"){
            triggers.Remove(other.gameObject);
        }
    }
}
