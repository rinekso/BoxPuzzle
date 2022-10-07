using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeAction : MonoBehaviour,Interactor
{
    public Transform point;
    public Transform point2;
    public float speed;
    public float delay;
    public int[] dialogInitAfter;
    public GameObject hiddenObject;
    int shakeValue;
    [SerializeField]
    Transform hiddenLocation;
    [SerializeField]
    bool hiddenDrop = true;
    public void Action(){
        SoundController.Instance.PlayEffect(2);
        GetComponent<Animator>().SetTrigger("move");
        GameController.instance.MoveMain(point2.position,speed,delay,delegate {
            int point = PlayerPrefs.GetInt("Main-TreePoint");
            if(point<dialogInitAfter.Length){
                DialogAssets.instance.InitDialog(dialogInitAfter[point]);
            }
            point++;
            PlayerPrefs.SetInt("Main-TreePoint",point);
        });

        GameObject.FindObjectOfType<TreeIndicator>().AddTreeAction(this);
    }
    public void HardShake(){
        GetComponent<Animator>().SetTrigger("hardtrigger");
        if(hiddenDrop) {
            Instantiate(hiddenObject,hiddenLocation.position, hiddenObject.transform.rotation);
            hiddenDrop = false;
        }
    }
}
