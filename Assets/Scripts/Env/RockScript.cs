using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockScript : MonoBehaviour, Interactor
{
    public void Action(){
        SoundController.Instance.PlayEffect(1);
        Inventory.instance.AddItem("rock",4);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
