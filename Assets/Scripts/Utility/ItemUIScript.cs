using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemUIScript : MonoBehaviour
{
    Canvas canvas;
    GameObject temp;
    private void Start() {
        canvas = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<Canvas>();
    }
    public void DragHandler(){
        temp.transform.position = Input.mousePosition; 
    }
    public void StartDragging(){
        temp = new GameObject();
        temp.transform.parent = canvas.transform;
        temp.AddComponent<Image>().sprite = GetComponent<Image>().sprite;
        temp.GetComponent<RectTransform>().sizeDelta = new Vector2(100,100);

        InventoryUIScript.instance.BackgroundBlack.SetActive(true);
    }
    public void Dropping(){
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;
        List<RaycastResult> raysastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, raysastResults);
        foreach (RaycastResult raysastResult in raysastResults)
        {
            print(raysastResult.gameObject.name);
        }
        Destroy(temp);
        InventoryUIScript.instance.BackgroundBlack.SetActive(false);
    }
}
