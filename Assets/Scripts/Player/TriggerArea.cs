using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// For save object
public class TriggerArea : MonoBehaviour
{
    [SerializeField]
    string specificName;
    public List<GameObject> triggers;
    [SerializeField]
    bool dontEmpty = false;
    private void OnTriggerEnter(Collider other) {
        // print(other.tag);
        if(other.tag == "Triggerer" && !triggers.Contains(other.gameObject)){
            if(!string.IsNullOrEmpty(specificName)){
                if(other.GetComponent<TriggererProperty>().name == specificName){
                    triggers.Add(other.gameObject);
                    if(other.TryGetComponent<ITriggerer>(out ITriggerer triggerer)) triggerer.Reaction(); 
                }
            }else{
                triggers.Add(other.gameObject);
                if(other.TryGetComponent<ITriggerer>(out ITriggerer triggerere)) triggerere.Reaction(); 
            }
        }
    }
    private void OnTriggerStay(Collider other) {
        
    }
    private void OnTriggerExit(Collider other) {
        if(!GetComponent<Collider>().isTrigger) return;
        if(other.tag == "Triggerer"){
            if(!dontEmpty)
                triggers.Remove(other.gameObject);
            else{
                if(triggers.Count > 1)
                    triggers.Remove(other.gameObject);
            }
        }
    }
}
