using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScript : MonoBehaviour
{
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
