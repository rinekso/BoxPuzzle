using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LighterScript : MonoBehaviour, ITriggerer
{
    [SerializeField]
    string dialog;
    public void Reaction(){
        GameController.instance.MoveMain(transform.position,3,1, delegate {
            DialogAssets.instance.InitDialog(dialog);
            Destroy(gameObject);
        },2);
    }
}
