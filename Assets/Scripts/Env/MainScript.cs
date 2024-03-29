using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScript : MonoBehaviour
{
    Animator animator;
    float idleTemp = 0;
    private void Start() {
        animator = GetComponentInChildren<Animator>();
        InvokeRepeating("SetRandomIdleAnimation",0,10);
    }
    void SetRandomIdleAnimation(){
        StartCoroutine(TransitionIdleAnimation());
    }
    IEnumerator TransitionIdleAnimation(){
        float newIdleTemp = Random.Range(0f,1f);
        float t = 0;
        float duration = 5;
        float startIdle = idleTemp;
        while (t < 1)
        {
            yield return null;
            t += Time.deltaTime/duration;

            idleTemp = Mathf.Lerp(startIdle,newIdleTemp,t);
            animator.SetFloat("Random",idleTemp);
        }
        idleTemp = newIdleTemp;
        animator.SetFloat("Random",idleTemp);
    }
    public async void FindFarestTree(){
        GetComponent<TriggerArea>().triggers.RemoveAll(item => item == null);
        print("remove");
        List<GameObject> trees = GetComponent<TriggerArea>().triggers.FindAll( x => {
            if(x.GetComponent<TriggererProperty>())
                return x.GetComponent<TriggererProperty>().name == "tree";
            else
                return x.name == "tree";
        });
        GameObject farTree = trees[0];
        float far = 0;
        foreach (var item in trees)
        {
            if(far < Vector3.Distance(transform.position,item.transform.position))
            {
                farTree = item;
                far = Vector3.Distance(transform.position,item.transform.position);
            }
        }
        GameController.instance.MoveMain(farTree.GetComponent<TreeAction>().point2.position,3,1,delegate {
            DialogAssets.instance.InitDialog("FearOfBox");
        });
    }
}
