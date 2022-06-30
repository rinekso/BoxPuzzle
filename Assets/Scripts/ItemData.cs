using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rinekso.Item {
    [CreateAssetMenu(fileName = "New Item Asset", menuName = "Rinekso/ItemAsset")]
    public class ItemData : ScriptableObject
    {
        public List<Item> items;
    }
    [System.Serializable]
    public struct Item{
        public string name;
        public Sprite icon;
        public GameObject prefabs;
    }
}
