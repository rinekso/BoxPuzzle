using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.DeleteKey("FirstCinematic");
        if(PlayerPrefs.GetInt("FirstCinematic") == 0){
            DialogAssets.instance.InitDialog(1);
            PlayerPrefs.SetInt("FirstCinematic",1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
