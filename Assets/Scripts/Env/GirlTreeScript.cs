using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GirlTreeScript : MonoBehaviour, ITriggerer
{
    public TreeAction currentTree;
    [SerializeField]
    int dialogTriggerer;
    // [SerializeField]
    // UnityEvent GirlReaction;
    public void Strees(){
        if(currentTree != null)
            currentTree.HardShake();
    }
    public void Reaction(){
        // GirlReaction.Invoke();
        DialogAssets.instance.InitDialog(dialogTriggerer);
    }
    public void ComeCloserToGirl(){
        GameController.instance.MoveMain(transform.position,3,1,null,2);
    }
}
