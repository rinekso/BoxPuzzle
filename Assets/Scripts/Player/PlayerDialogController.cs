using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDialogController : MonoBehaviour
{
    public GameObject notifUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowNotif(bool set){
        notifUI.SetActive(set);
    }
}
