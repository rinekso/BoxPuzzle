using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;
using Rinekso.Item;
using System.Linq;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    [SerializeField]
    Transform itemSpawn;
    [SerializeField]
    ItemData itemData;
    [System.Serializable]
    public struct InventoryItem{
        public Item item;
        public int value;
    }
    public List<InventoryItem> currentInventory;
    Item FindItem(string name){
        return itemData.items.Find(x => x.name == name);
    }
    private void Awake() {
        instance = this;
    }
    public void AddItem(string name, int val){
        Item itemKind = FindItem(name);
        InventoryItem searchItem = currentInventory.Find(x => x.item.name == itemKind.name);
        InventoryItem tempItem = new InventoryItem();
        if(searchItem.item.name != null){
            tempItem = currentInventory[currentInventory.IndexOf(searchItem)];
            if(tempItem.value+val <= itemKind.maxValue)
                tempItem.value += val;
            else
                tempItem.value = itemKind.maxValue;
            currentInventory[currentInventory.IndexOf(searchItem)] = tempItem;
        }else{
            tempItem.item = itemKind;
            tempItem.value = val;
            currentInventory.Add(tempItem);
        }
    }
    public void RemoveItem(int id, int val){
        InventoryItem tempItem = new InventoryItem();
        tempItem = currentInventory[id];
        if(currentInventory[id].value > 1){
            tempItem.value -= val;
            currentInventory[id] = tempItem;
        }else{
            currentInventory.Remove(tempItem);
        }
    }
    bool isInventoryHasIt(Item it){
        return currentInventory.Any(x => x.item.name == it.name);
    }
    public void DropItem(int id){
        GameObject go = Instantiate(currentInventory[id].item.prefabs);
        go.transform.position = itemSpawn.position;
        RemoveItem(id,1);
        InventoryUIScript.instance.RefreshItem();
    }
}
