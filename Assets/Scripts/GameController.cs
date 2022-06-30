using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    public enum Interaction
    {
        Dialog, Action, Get, Put
    }
    public static GameController instance;
    [Header("UI")]
    public GameObject interactButton;
    public GameObject grabButton;
    public GameObject dropButton;
    public Button jumpButton;
    [Header("Player")]
    public GameObject playerPrefabs;
    public GameObject currentPlayer;
    public GameObject mainPlayer;
    PlayerStat playerStat;
    [Header("Others")]
    public ObjectFollow camPlace;
    public Transform[] pointStart;
    public Animator animator;
    int currentPointStart = 0;
    [SerializeField]
    bool initPlayerFirst = false;
    public Interaction currentTypeInteraction;
    public int currentIdInteraction;
    public GameObject currentGOInteraction;
    private void Awake() {
        PlayerPrefs.DeleteAll();
        instance = this;

        if(initPlayerFirst) InitPlayer();
    }
    void InitPlayer(){
        // currentPlayer = Instantiate(playerPrefabs);
        playerStat = currentPlayer.GetComponent<PlayerStat>();
        currentPlayer.transform.position = pointStart[currentPointStart].position;
        camPlace.target = currentPlayer.transform;

        dropButton.SetActive(false);
        grabButton.SetActive(false);
    }
    public void ActiveGrab(bool stat){
        grabButton.SetActive(stat);
    }
    public void ActiveInteraction(bool stat){
        interactButton.SetActive(stat);
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
    void InteractObject(){
        currentGOInteraction.GetComponent<Interactor>().Action();
        currentPlayer.GetComponentInChildren<MainPlayerScript>().StopMonolog();
    }
    public void MoveMain(Vector3 target, float speed, float delay, UnityAction callback = null, float distance = .2f){
        StartCoroutine(Move(mainPlayer,target,speed,delay,callback, distance));
    }
    IEnumerator Move(GameObject target, Vector3 endPoint, float speed = 1, float delay = 0, UnityAction callback = null, float distance = .2f){
        yield return new WaitForSeconds(delay);
        Vector3 start = target.transform.position;
        Vector3 direction = (endPoint-start).normalized;
        while (Vector3.Distance(endPoint,target.transform.position) > distance)
        {
            target.transform.position = target.transform.position + direction * speed * Time.deltaTime;
            yield return null;
        }
        if(callback != null) callback.Invoke();
        // target.transform.position = endPoint;
    }
    public void DoInteraction(){
        switch (currentTypeInteraction)
        {
            case Interaction.Dialog:
                DialogAssets.instance.InitDialog(currentIdInteraction);
            break;
            case Interaction.Action:
                InteractObject();
            break;
            case Interaction.Get:
            
            break;
            case Interaction.Put:

            break;
            default:
            break;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
