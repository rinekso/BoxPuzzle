using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchScript : MonoBehaviour, Interactor
{
    public Transform point;
    public float speed;
    public float delay;
    public int[] dialogInitAfter;
    public void Action(){
        GameController.instance.MoveMain(point.position,speed,delay,delegate {
            DialogAssets.instance.InitDialog(dialogInitAfter[0]);
        });
    }
}
