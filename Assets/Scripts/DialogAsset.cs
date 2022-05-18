using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rinekso.Dialog {
    [CreateAssetMenu(fileName = "New Dialog Asset", menuName = "Rinekso/DialogAsset")]
    public class DialogAsset : ScriptableObject
    {
        public Char[] charImage;
        public List<Dialog> dialog;
    }

    [System.Serializable]
    public struct Char{
        public string name;
        public Sprite charImage;
    }
    [System.Serializable]
    public struct Dialog
    {
        public string name;
        public List<Conversation> conversations;
    }
    [System.Serializable]
    public struct Choice
    {
        public string textDisplay;
        public bool openDialog;
        public int dialogId;
        public string action;
    }
    [System.Serializable]
    public struct Conversation{
        public int charId;
        public bool isRight;
        public string conv;
        public string action;
        public Choice[] choices;
    }
}
