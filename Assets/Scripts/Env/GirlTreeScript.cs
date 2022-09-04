using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GirlTreeScript : MonoBehaviour, ITriggerer, IObjectDetectionEvent, IMonologAction
{
    public TreeAction currentTree;
    [SerializeField]
    int dialogTriggerer;
    [SerializeField]
    string dialogClose;
    MainPlayerScript monologController;
    Animator animator;
    private void Start() {
        monologController = GetComponentInChildren<MainPlayerScript>();
        monologController.StartMonolog("tree",true);
        animator = GetComponent<Animator>();
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
    bool findTree = false;
    bool find = false;
    // Detection Object
    public void TriggerEnter(GameObject target){

    }
    public void TriggerExit(GameObject target){

    }
    public void TriggerStay(GameObject target){
        if(!find){
            print(target.name);
            if(!findTree){
                animator.SetBool("stress",true);
                // print(target.transform.position);
                StartCoroutine(GameController.instance.Move(gameObject,target.transform.position,2,0,delegate {
                    print("finish to rock");
                    Destroy(target.gameObject);
                    monologController.StartMonolog("rock",false);
                    findTree = true;
                },.5f));
            }else{
            }
            find = true;
        }
    }
    void ResetDetection(){
        find = false;
    }
    public void GetInvoke(string func){
        Invoke(func,0);
    }
    public void FindTree(){

        TriggerArea triggerArea = GetComponent<TriggerArea>();
        triggerArea.triggers.Remove(currentTree.gameObject);
        if(triggerArea.triggers.Count > 0){
            
            // move
            StartCoroutine(GameController.instance.Move(gameObject,triggerArea.triggers[0].GetComponent<TreeAction>().point.position,2,0,delegate {
                ResetDetection();

                currentTree = triggerArea.triggers[0].GetComponent<TreeAction>();
                animator.SetBool("stress",false);
                monologController.StartMonolog("tree",true);
                findTree = false;
            },.5f));
        }

    }
}
