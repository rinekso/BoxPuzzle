using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScript : MonoBehaviour
{
    public void FindFarestTree(){
        List<GameObject> trees = GetComponent<TriggerArea>().triggers.FindAll( x => {
            return x.GetComponent<TriggererProperty>().name == "tree";
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
