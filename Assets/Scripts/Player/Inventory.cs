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
    ItemData itemData;
    public List<InventoryItem> currentInventory;
    [System.Serializable]
    public struct InventoryItem{
        public Item item;
        public int value;
    }
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
            tempItem.value += val;
            currentInventory[currentInventory.IndexOf(searchItem)] = tempItem;
        }else{
            tempItem.item = itemKind;
            tempItem.value = val;
            currentInventory.Add(tempItem);
        }
    }
    bool isInventoryHasIt(Item it){
        return currentInventory.Any(x => x.item.name == it.name);
    }
}
