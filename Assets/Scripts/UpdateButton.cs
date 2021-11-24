using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UpdateButton : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler
{
    public UnityEvent onDown;
    public UnityEvent onEnter;
    public UnityEvent onExit;
    public UnityEvent onUp;
    public void OnPointerDown(PointerEventData ped){
        onDown.Invoke();
    }
    public void OnPointerEnter(PointerEventData ped){
        onEnter.Invoke();
    }
    public void OnPointerExit(PointerEventData ped){
        onExit.Invoke();
    }
    public void OnPointerUp(PointerEventData ped){
        onUp.Invoke();
    }
}
