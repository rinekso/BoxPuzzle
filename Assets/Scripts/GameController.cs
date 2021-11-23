using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public GameObject grabButton;
    public GameObject playerPrefabs;
    GameObject currentPlayer;
    PlayerStat playerStat;
    public Transform[] pointStart;
    int currentPointStart = 0;
    private void Awake() {
        instance = this;

        InitPlayer();
    }
    void InitPlayer(){
        currentPlayer = Instantiate(playerPrefabs);
        playerStat = currentPlayer.GetComponent<PlayerStat>();
        currentPlayer.transform.position = pointStart[currentPointStart].position;
    }
    public void ActiveGrab(bool stat){
        grabButton.SetActive(stat);
    }
    public void SetObjectToPlayer(GameObject target){
        playerStat.targetObject = target;
    }
    public void GrabObject(){
        playerStat.GrabObject();
    }
    public void DropObject(){
        playerStat.DropObject();
    }
    public void UpdatePoin(){

    }
    public void Dead(){
        Destroy(currentPlayer);
        InitPlayer();
        // player.transform.position = pointStart[currentPointStart].position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
