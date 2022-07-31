using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryUIScript : MonoBehaviour
{
    public static InventoryUIScript instance;
    [SerializeField]
    GameObject inventoryPanel;
    [SerializeField]
    Inventory inventory;
    public GameObject BackgroundBlack;

    public GameObject itemUiPrefabs;
    private void Awake() {
        instance = this;
    }

    public void OpenInventory(bool val){
        inventoryPanel.SetActive(val);
        if(val) RefreshItem();
    }
    public void RefreshItem(){
        Transform container = inventoryPanel.transform.GetChild(0);
        DeleteAllItem(container);
        int key = 0;
        // print("refresh item length = "+inventory.currentInventory.Count);
        if(inventory.currentInventory.Count > 0)
            foreach (var item in inventory.currentInventory)
            {
                GameObject go = Instantiate(itemUiPrefabs,container);
                ApplyItemUI(go, item, key);
                key++;
            }
    }
    void ApplyItemUI(GameObject item, Inventory.InventoryItem data, int key){
        item.GetComponent<Image>().sprite = data.item.icon;
        item.GetComponent<ItemUIScript>().id = key;
        item.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = data.value+"";
    }
    void DeleteAllItem(Transform container){
        for (var i = 0; i < container.childCount; i++)
        {
            Destroy(container.GetChild(i).gameObject);
        }
    }
}
