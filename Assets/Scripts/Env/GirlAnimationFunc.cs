using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlAnimationFunc : MonoBehaviour
{
    [SerializeField]
    GirlTreeScript girlTree;
    public void Stress(){
        girlTree.Stress();
    }
}
