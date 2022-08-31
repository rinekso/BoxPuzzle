using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rinekso.Dialog;

public class MainPlayerScript : MonoBehaviour
{
    [SerializeField]
    MonologAsset monologAsset;
    [SerializeField]
    GameObject playerGameObject;
    public Transform containerText;
    public TMPro.TextMeshProUGUI dialog;
    bool startMonolog = false;
    [SerializeField]
    float speedWord;
    [SerializeField]
    float convDelay;
    Coroutine dialogTemp;
    int currentConv;
    [SerializeField]
    bool resetDialog = true;
    public void StartMonolog(string monolog, bool reset = true){
        resetDialog = reset;
        currentConv = 0;
        List<Monolog> result = monologAsset.dialog.FindAll(delegate (Monolog x)
        {
            return x.place == monolog;
        });
        if(dialogTemp != null)
            StopCoroutine(dialogTemp);
        if(result.Count > 0)
            dialogTemp = StartCoroutine(StartDialog(result[0]));
    }
    public void StopMonolog(){
        containerText.gameObject.SetActive(false);
        if(dialogTemp != null)
            StopCoroutine(dialogTemp);
    }
    IEnumerator StartDialog(Monolog log){
        containerText.gameObject.SetActive(true);
        for (int i = 0; i < log.conv.Count; i++)
        {
            // print(log.conv[currentConv]);
            yield return DialogRunning(log.conv[currentConv]);
            currentConv++;
        }
        currentConv = 0;
        containerText.gameObject.SetActive(false);
        if(resetDialog){
            yield return new WaitForSeconds(convDelay*30);
            yield return StartDialog(log);
        }else{
            if(!string.IsNullOrEmpty(log.action)){
                playerGameObject.GetComponent<IMonologAction>().GetInvoke(log.action);
            }
        }
    }
    public IEnumerator DialogRunning(string conv){
        dialog.text = "";
        for (int i = 0; i < conv.Length; i++)
        {
            yield return new WaitForSeconds(speedWord);
            dialog.text += conv[i];
        }
        yield return new WaitForSeconds(convDelay*conv.Length);
        containerText.gameObject.SetActive(true);
    }
}
