using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rinekso.Dialog {
    [CreateAssetMenu(fileName = "New Monolog Asset", menuName = "Rinekso/MonologAsset")]
    public class MonologAsset : ScriptableObject
    {
        public List<Monolog> dialog;
    }

    [System.Serializable]
    public struct Monolog{
        public string place;
        public string action;
        public List<string> conv;
    }
}
