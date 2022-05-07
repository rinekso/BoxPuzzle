using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmotionIndicator : MonoBehaviour
{
    public Transform dot;
    PlayerChar playerChar;
    // Start is called before the first frame update
    void Start()
    {
        playerChar = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerChar>();
        UpdatePoint();
    }
    // [Button("asd")]
    public void UpdatePoint(){
        float totalAngerCalm = playerChar.angerPoint+playerChar.calmPoint;
        float totalSeriousFunny = playerChar.seriousPoint+playerChar.funnyPoint;

        RectTransform rectTransform = dot.GetComponent<RectTransform>();
        Vector2 newPos = new Vector2(
            (float)(playerChar.funnyPoint/totalSeriousFunny)*300,
            (float)(playerChar.angerPoint/totalAngerCalm)*300
        );
        rectTransform.anchoredPosition = newPos;
    }
    void Update()
    {
    }
}
