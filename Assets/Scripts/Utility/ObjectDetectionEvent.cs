using UnityEngine;

public interface IObjectDetectionEvent
{
    public void TriggerEnter(GameObject target);
    public void TriggerExit(GameObject target);
    public void TriggerStay(GameObject target);
}
