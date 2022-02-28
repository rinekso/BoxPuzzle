using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rinekso.Interface;

public class BlockActive : MonoBehaviour, IPlatformInterface
{
    public void OnActive(){
        GetComponent<Animator>().SetBool("active",true);
    }
    public void OnDeactive(){
        GetComponent<Animator>().SetBool("active",false);
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
