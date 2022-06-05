using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeAction : MonoBehaviour,Interactor
{
    public Transform point;
    public float speed;
    public float delay;
    public int dialogInitAfter;
    public void Action(){
        GetComponent<Animator>().SetTrigger("move");
        GameController.instance.MoveMain(point.position,speed,delay,delegate {
            DialogAssets.instance.InitDialog(dialogInitAfter);
        });
    }
    public void HardShake(){
        GetComponent<Animator>().SetTrigger("hardtrigger");
    }
}
