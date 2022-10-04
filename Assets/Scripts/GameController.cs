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
    public bool isInteraction = true;
    [SerializeField]
    GameObject interactButton;
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
    Coroutine move;
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

    }
    public void ActiveGrab(bool stat){
        // grabButton.SetActive(stat);
    }
    public void ActiveInteraction(bool stat){
        interactButton.SetActive(stat);
    }
    public void SetObjectToPlayer(GameObject target){
        playerStat.targetObject = target;
    }
    public void GrabObject(){
        playerStat.GrabObject();
        // dropButton.SetActive(true);
        // grabButton.SetActive(false);
    }
    public void DropObject(){
        if(playerStat.isFrontEmpty){
            playerStat.DropObject();
            // dropButton.SetActive(false);
            // grabButton.SetActive(true);
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
        // currentPlayer.GetComponentInChildren<MainPlayerScript>().StopMonolog();
    }
    public void MoveMain(Vector3 target, float speed, float delay, UnityAction callback = null, float distance = .2f){
        // print(target);
        if(move != null) StopCoroutine(move);
        move = StartCoroutine(DoMove(mainPlayer,target,speed,delay,callback, distance));
    }
    public void Move(GameObject target, Vector3 endPoint, float speed = 1, float delay = 0, UnityAction callback = null, float distance = .2f){
        if(move != null) StopCoroutine(move);
        move = StartCoroutine(DoMove(target,endPoint,speed,delay,callback,distance));
    }
    public IEnumerator DoMove(GameObject target, Vector3 endPoint, float speed = 1, float delay = 0, UnityAction callback = null, float distance = .2f){
        Quaternion rotation = Quaternion.LookRotation((endPoint-target.transform.position), Vector3.up);
        target.transform.rotation = rotation;
        isInteraction = false;
        // print(target.name);
        yield return new WaitForSeconds(delay);
        Vector3 start = target.transform.position;
        Vector3 direction = (endPoint-start).normalized;
        while (Vector3.Distance(endPoint,target.transform.position) > distance)
        {
            target.transform.position = target.transform.position + direction * speed * Time.deltaTime;
            yield return null;
        }
        // smoothing movement
        float t = 0;
        float duration = 1f;
        while (t < 1){
            yield return null;
            t += Time.deltaTime / duration;
            target.transform.position = Vector3.Lerp(target.transform.position,endPoint,t);
        }
        target.transform.position = endPoint;
        isInteraction = true;
        if(callback != null) callback.Invoke();
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
        interactButton.GetComponent<Button>().interactable = isInteraction;
    }
    public void EndLevel(){
        camPlace.target = null;
    }
    public void MoveNextLevel(string scene){
        animator.SetTrigger("Start");
        Application.LoadLevel(scene);
    }
}
