using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    [Header("UI")]
    public GameObject grabButton;
    public GameObject dropButton;
    public Button jumpButton;
    [Header("Player")]
    public GameObject playerPrefabs;
    public GameObject currentPlayer;
    PlayerStat playerStat;
    [Header("Others")]
    public ObjectFollow camPlace;
    public Transform[] pointStart;
    public Animator animator;
    int currentPointStart = 0;
    [SerializeField]
    bool initPlayerFirst = false;
    private void Awake() {
        instance = this;

        if(initPlayerFirst) InitPlayer();
    }
    void InitPlayer(){
        currentPlayer = Instantiate(playerPrefabs);
        playerStat = currentPlayer.GetComponent<PlayerStat>();
        currentPlayer.transform.position = pointStart[currentPointStart].position;
        camPlace.target = currentPlayer.transform;

        dropButton.SetActive(false);
        grabButton.SetActive(false);

        
    }
    public void ActiveGrab(bool stat){
        grabButton.SetActive(stat);
    }
    public void SetObjectToPlayer(GameObject target){
        playerStat.targetObject = target;
    }
    public void GrabObject(){
        playerStat.GrabObject();
        dropButton.SetActive(true);
        grabButton.SetActive(false);
    }
    public void DropObject(){
        if(playerStat.isFrontEmpty){
            playerStat.DropObject();
            dropButton.SetActive(false);
            grabButton.SetActive(true);
        }
    }
    public void Jump(){
        currentPlayer.GetComponent<PlayerMovment>().Jump();
    }
    public void Dash(){
        currentPlayer.GetComponent<PlayerMovment>().Dash();
    }
    public void UpdatePoin(){

    }
    public void Dead(){
        if(playerStat.objectTemp.childCount > 0){
            DropObject();
        }
        Destroy(currentPlayer);
        InitPlayer();
        // player.transform.position = pointStart[currentPointStart].position;
    }

    public void JumpLevel(int index){
        StartCoroutine(LevelRuntime(index));
    }
    IEnumerator LevelRuntime(int index){
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        Application.LoadLevel(index);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
