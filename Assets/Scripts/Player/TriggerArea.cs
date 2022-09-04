using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerArea : MonoBehaviour
{
    [SerializeField]
    string triggerTag;
    public List<GameObject> triggers;
    private void OnTriggerEnter(Collider other) {
        // print(other.tag);
        if(other.tag == triggerTag && !triggers.Contains(other.gameObject)){
            triggers.Add(other.gameObject);
            if(other.TryGetComponent<ITriggerer>(out ITriggerer triggerer)) triggerer.Reaction(); 
        }
    }
    private void OnTriggerExit(Collider other) {
        if(!GetComponent<Collider>().isTrigger) return;
        if(other.tag == triggerTag){
            triggers.Remove(other.gameObject);
        }
    }
}
