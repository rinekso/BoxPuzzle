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
    [SerializeField]
    MainPlayerScript monologController;
    Animator animator;
    private void Start() {
        monologController.StartMonolog("tree",true);
        animator = GetComponentInChildren<Animator>();
    }
    // [SerializeField]
    // UnityEvent GirlReaction;
    public void Stress(){
        if(currentTree != null)
            currentTree.HardShake();
    }
    public void Reaction(){
        // GirlReaction.Invoke();
        // monologController.StopMonolog();
        DialogAssets.instance.InitDialog(dialogTriggerer);
    }
    public void ComeCloserToGirl(){
        GameController.instance.MoveMain(currentTree.point2.position,5,1, delegate {
            DialogAssets.instance.InitDialog(dialogClose);
        },.2f);
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
                GameController.instance.Move(gameObject,target.transform.position,2,0,delegate {
                    print("finish to rock");
                    Destroy(target.gameObject);
                    animator.SetTrigger("pick");
                    monologController.StartMonolog("rock",false);
                    findTree = true;
                },.5f);
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
        List<GameObject> trees = new List<GameObject>(triggerArea.triggers);
        if(trees.Count > 1)
            trees.Remove(currentTree.gameObject);
        GameObject nearTree = triggerArea.triggers[0];
        float near = 100;
        foreach (var item in trees)
        {
            if(near > Vector3.Distance(transform.position,item.transform.position))
            {
                nearTree = item;
                near = Vector3.Distance(transform.position,item.transform.position);
            }
        }
        // move
        GameController.instance.Move(gameObject,nearTree.GetComponent<TreeAction>().point.position,2,0,delegate {
            ResetDetection();
            transform.rotation = new Quaternion();

            currentTree = triggerArea.triggers[0].GetComponent<TreeAction>();
            animator.SetBool("stress",false);
            monologController.StartMonolog("tree",true);
            findTree = false;
        },.5f);

    }
}
