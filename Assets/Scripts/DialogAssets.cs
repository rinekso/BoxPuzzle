using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rinekso.Dialog;
using UnityEngine.Events;
using UnityEngine.UI;

public class DialogAssets : MonoBehaviour
{
    public static DialogAssets instance;
    [SerializeField]
    DialogAsset dialogAsset;
    public GameObject pictRight;
    public GameObject pictLeft;
    public TMPro.TextMeshProUGUI dialog;
    [SerializeField]
    Transform container;
    [SerializeField]
    bool autoNext;
    public bool next = false;
    [SerializeField]
    float speedWord;
    [SerializeField]
    float convDelay;
    int currentConv;
    public List<ActionSet> actionList;
    [System.Serializable]
    public struct ActionSet
    {
        public string name;
        public UnityEvent action;
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    public void InitDialog(int index){
        currentConv = 0;
        container.gameObject.SetActive(true);
        StartCoroutine(StartDialog(index));
    }
    public void DialogClose(){
        container.gameObject.SetActive(false);
    }
    IEnumerator StartDialog(int index){
        for (int i = 0; i < dialogAsset.dialog[index].conversations.Count; i++)
        {
            pictLeft.SetActive(!dialogAsset.dialog[index].conversations[currentConv].isRight);
            pictRight.SetActive(dialogAsset.dialog[index].conversations[currentConv].isRight);
            pictLeft.GetComponent<Image>().sprite = dialogAsset.charImage[dialogAsset.dialog[index].conversations[currentConv].charId].charImage;
            pictRight.GetComponent<Image>().sprite = dialogAsset.charImage[dialogAsset.dialog[index].conversations[currentConv].charId].charImage;

            yield return DialogRunning(dialogAsset.dialog[index].conversations[currentConv].conv);
            if(dialogAsset.dialog[index].conversations[currentConv].action != ""){
                actionList.Find(x => x.name == dialogAsset.dialog[index].conversations[currentConv].action).action.Invoke();
            }else{

            }
            currentConv++;
        }
        currentConv = 0;
        DialogClose();
    }
    public void NextDialog(){
        next = true;
    }
    IEnumerator DialogRunning(string conv){
        dialog.text = "";
        for (int i = 0; i < conv.Length; i++)
        {
            yield return new WaitForSeconds(speedWord);
            dialog.text += conv[i];
        }
        if(!autoNext){
            while (!next)
            {
                yield return null;
            }
            next = false;
        }
        yield return new WaitForSeconds(convDelay);
    }
}
