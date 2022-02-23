using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rinekso.Dialog;
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
        public event Action action;
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
    IEnumerator StartDialog(int index){
        for (int i = 0; i < dialogAsset.dialog[index].conversations.Count; i++)
        {
            pictLeft.SetActive(!dialogAsset.dialog[index].conversations[currentConv].isRight);
            pictRight.SetActive(dialogAsset.dialog[index].conversations[currentConv].isRight);
            print(dialogAsset.dialog[index].conversations[currentConv].charId);
            pictLeft.GetComponent<Image>().sprite = dialogAsset.charImage[dialogAsset.dialog[index].conversations[currentConv].charId].charImage;
            pictRight.GetComponent<Image>().sprite = dialogAsset.charImage[dialogAsset.dialog[index].conversations[currentConv].charId].charImage;
            yield return DialogRunning(dialogAsset.dialog[index].conversations[currentConv].conv);
            if(dialogAsset.dialog[index].conversations[currentConv].action != null){
                // actionList.Find(x => x.name == dialogAsset.dialog[index].conversations[currentConv].action).action.Invoke();
            }
            currentConv++;
        }
        currentConv = 0;

    }
    IEnumerator DialogRunning(string conv){
        dialog.text = "";
        for (int i = 0; i < conv.Length; i++)
        {
            yield return new WaitForSeconds(speedWord);
            dialog.text += conv[i];
        }
        while (!autoNext)
        {
            yield return null;            
        }
        yield return new WaitForSeconds(convDelay);
    }
}
