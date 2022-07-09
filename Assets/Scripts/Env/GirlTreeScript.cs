using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GirlTreeScript : MonoBehaviour, ITriggerer
{
    public TreeAction currentTree;
    [SerializeField]
    int dialogTriggerer;
    [SerializeField]
    string dialogClose;
    MainPlayerScript monologController;
    private void Start() {
        monologController = GetComponentInChildren<MainPlayerScript>();
        monologController.StartMonolog("tree",true);
    }
    // [SerializeField]
    // UnityEvent GirlReaction;
    public void Strees(){
        if(currentTree != null)
            currentTree.HardShake();
    }
    public void Reaction(){
        // GirlReaction.Invoke();
        // monologController.StopMonolog();
        DialogAssets.instance.InitDialog(dialogTriggerer);
    }
    public void ComeCloserToGirl(){
        GameController.instance.MoveMain(transform.position,3,1, delegate {
            DialogAssets.instance.InitDialog(dialogClose);
        },2);
    }
}
