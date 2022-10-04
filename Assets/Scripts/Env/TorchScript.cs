using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TorchScript : MonoBehaviour, Interactor, ITriggerer
{
    public Transform point;
    public float speed;
    public float delay;
    public int[] dialogInitAfter;
    [SerializeField]
    GameObject mist;
    [SerializeField]
    GameObject fire;
    [SerializeField]
    Transform finalPoint;
    public void Action(){
        GameController.instance.MoveMain(point.position,speed,delay,delegate {
            DialogAssets.instance.InitDialog(dialogInitAfter[0]);
        });
    }
    public void Reaction(){
        GameController.instance.MoveMain(point.position,speed,delay,delegate {
            DialogAssets.instance.InitDialog(dialogInitAfter[0]);
        });
    }
    public void GoToTorch(){
        GameController.instance.MoveMain(point.position,speed,delay,delegate {
            fire.SetActive(true);
            mist.GetComponentInChildren<ParticleSystem>().loop = false;
            mist.GetComponentInChildren<BoxCollider>().enabled = false;
            GameController.instance.EndLevel();
            GameController.instance.MoveMain(finalPoint.position,speed,5,delegate {
                GameController.instance.MoveNextLevel("Limbo2");
            });
        });
    }
}
