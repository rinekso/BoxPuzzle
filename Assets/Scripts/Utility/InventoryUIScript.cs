using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryUIScript : MonoBehaviour
{
    [SerializeField]
    GameObject inventoryPanel;
    [SerializeField]
    Inventory inventory;

    public GameObject itemUiPrefabs;

    public void OpenInventory(bool val){
        inventoryPanel.SetActive(val);
        if(val) RefreshItem();
    }
    void RefreshItem(){
        Transform container = inventoryPanel.transform.GetChild(0);
        DeleteAllItem(container);
        foreach (var item in inventory.currentInventory)
        {
            GameObject go = Instantiate(itemUiPrefabs,container);
            ApplyItemUI(go, item);
        }
    }
    void ApplyItemUI(GameObject item, Inventory.InventoryItem data){
        item.GetComponent<Image>().sprite = data.item.icon;
        item.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = data.value+"";
    }
    void DeleteAllItem(Transform container){
        for (var i = 0; i < container.childCount; i++)
        {
            Destroy(container.GetChild(i).gameObject);
        }
    }
}
