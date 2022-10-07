using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeIndicator : MonoBehaviour
{
    TreeAction treeAction;
    int currentCount = 0;
    int completeAmount = 3;
    public void AddTreeAction(TreeAction _treeAction){
        if(treeAction != _treeAction){
            currentCount = 0;
            treeAction = _treeAction;
        }else{
            currentCount++;
            CheckingComplete();
        }
    }
    void CheckingComplete(){
        if(currentCount >= completeAmount){
            treeAction.HardShake();
        }
    }
}
