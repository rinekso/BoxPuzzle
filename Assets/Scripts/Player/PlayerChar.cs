using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChar : MonoBehaviour
{
    public float Openness = 50;
    [SerializeField]
    GameObject OPNDot;
    public float Extraversion = 50;
    [SerializeField]
    GameObject EXTDot;
    public float Consceintiousness = 50;
    [SerializeField]
    GameObject CONDot;
    public float Neuroticism = 50;
    [SerializeField]
    GameObject NEUDot;
    public float Agreebleness = 50;
    [SerializeField]
    GameObject AGRDot;

    private void Awake() {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        PositionPersonalities();
    }
    void PositionPersonalities(){
        print("char set");
        OPNDot.GetComponent<RectTransform>().anchoredPosition = new Vector2(0,Openness);
        EXTDot.GetComponent<RectTransform>().anchoredPosition = new Vector2(0,Extraversion);
        CONDot.GetComponent<RectTransform>().anchoredPosition = new Vector2(0,Consceintiousness);
        NEUDot.GetComponent<RectTransform>().anchoredPosition = new Vector2(0,Neuroticism);
        AGRDot.GetComponent<RectTransform>().anchoredPosition = new Vector2(0,Agreebleness);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
