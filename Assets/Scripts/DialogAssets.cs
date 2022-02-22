using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rinekso.Dialog;

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
    public void InitDialog(){
        container.gameObject.SetActive(true);
    }
}
