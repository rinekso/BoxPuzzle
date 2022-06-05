using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlTreeScript : MonoBehaviour
{
    public TreeAction currentTree;
    public void Strees(){
        if(currentTree != null)
            currentTree.HardShake();
    }
}
