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
    Transform containerChoice;
    [SerializeField]
    Transform containerDialog;
    [SerializeField]
    bool autoNext;
    public bool next = false;
    [SerializeField]
    float speedWord;
    [SerializeField]
    float convDelay;
    int currentConv;
    [SerializeField]
    GameObject buttonChoice;
    bool choosed = false;
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
        GameController.instance.currentPlayer.GetComponent<PlayerMovment>().canMove = false;
        currentConv = 0;
        container.gameObject.SetActive(true);
        containerDialog.gameObject.SetActive(true);
        containerChoice.gameObject.SetActive(false);
        StopAllCoroutines();
        StartCoroutine(StartDialog(index));
    }
    public void DialogClose(){
        container.gameObject.SetActive(false);
        GameController.instance.currentPlayer.GetComponent<PlayerMovment>().canMove = true;
    }
    IEnumerator StartDialog(int index){
        for (int i = 0; i < dialogAsset.dialog[index].conversations.Count; i++)
        {
            next = false;
            pictLeft.SetActive(!dialogAsset.dialog[index].conversations[currentConv].isRight);
            pictRight.SetActive(dialogAsset.dialog[index].conversations[currentConv].isRight);
            pictLeft.GetComponent<Image>().sprite = dialogAsset.charImage[dialogAsset.dialog[index].conversations[currentConv].charId].charImage;
            pictRight.GetComponent<Image>().sprite = dialogAsset.charImage[dialogAsset.dialog[index].conversations[currentConv].charId].charImage;

            yield return DialogRunning(dialogAsset.dialog[index].conversations[currentConv].conv);
            if(!string.IsNullOrEmpty(dialogAsset.dialog[index].conversations[currentConv].action)){
                actionList.Find(x => x.name == dialogAsset.dialog[index].conversations[currentConv].action).action.Invoke();
            }else{

            }
            if(dialogAsset.dialog[index].conversations[currentConv].choices.Length > 0){
                yield return ShowChoices(index);
            }
            currentConv++;
        }
        currentConv = 0;
        DialogClose();
    }
    public void NextDialog(){
        next = true;
    }
    IEnumerator ShowChoices(int index){
        choosed = false;
        containerChoice.gameObject.SetActive(true);
        containerDialog.gameObject.SetActive(false);
        DeleteAllChild(containerChoice);
        for (int i = 0; i < dialogAsset.dialog[index].conversations[currentConv].choices.Length; i++)
        {
            Choice choiceTemp = dialogAsset.dialog[index].conversations[currentConv].choices[i];
            GameObject btnTmp = Instantiate(buttonChoice,containerChoice);
            btnTmp.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = choiceTemp.textDisplay;
            if(choiceTemp.openDialog){
                btnTmp.GetComponent<Button>().onClick.AddListener( ()=>{
                    choosed = true;
                    InitDialog(choiceTemp.dialogId);
                } );
            }
            if(!string.IsNullOrEmpty(choiceTemp.action)){
                btnTmp.GetComponent<Button>().onClick.AddListener( ()=>{
                    choosed = true;
                    actionList.Find(x => x.name == choiceTemp.action).action.Invoke();
                });
            }
        }
        while (!choosed)
        {
            yield return null;
        }
    }
    void DeleteAllChild(Transform target){
        for (int i = 0; i < target.childCount; i++)
        {
            Destroy(target.GetChild(i).gameObject);
        }
    }
    IEnumerator DialogRunning(string conv){
        dialog.text = "";
        for (int i = 0; i < conv.Length; i++)
        {
            yield return new WaitForSeconds(speedWord);
            dialog.text += conv[i];
            if(next){ 
                dialog.text = conv;
                next = false;
                break;
            }
        }
        if(!autoNext){
            while (!next)
            {
                yield return null;
            }
            next = false;
        }else{
            yield return new WaitForSeconds(convDelay);
        }
    }
}
