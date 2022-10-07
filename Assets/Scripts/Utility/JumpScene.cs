using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScene : MonoBehaviour
{
    public void NextLevel(string scene){
        Application.LoadLevel(scene);
    }
}
