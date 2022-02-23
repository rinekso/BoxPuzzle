using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicEventDialog : MonoBehaviour
{
    public void InitDialog(){
        DialogAssets.instance.InitDialog(0);
    }
    public void LoadMainMenu(){
        GameController.instance.JumpLevel(1);
    }
}
