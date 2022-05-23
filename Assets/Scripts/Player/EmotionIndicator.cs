using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmotionIndicator : MonoBehaviour
{
    [System.Serializable]
    public struct Dot
    {
        public string name;
        public Transform point;
    }
    public List<Dot> dots;
    PlayerChar playerChar;
    [SerializeField]
    LineRenderer lineRenderer;
    // Start is called before the first frame update
    void Start()
    {
        playerChar = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerChar>();
        lineRenderer.positionCount = dots.Count;
        UpdatePoint();
        SpawnLine();
    }
    // [Button("asd")]
    public void UpdatePoint(){
        PointSet(dots[0].point,playerChar.Openness);
        PointSet(dots[1].point,playerChar.Extraversion);
        PointSet(dots[2].point,playerChar.Consceintiousness);
        PointSet(dots[3].point,playerChar.Neuroticism);
        PointSet(dots[4].point,playerChar.Agreebleness);
    }
    void SpawnLine(){
        for (int i = 0; i < dots.Count; i++)
        {
            lineRenderer.SetPosition(i,dots[i].point.position);
        }
    }
    void PointSet(Transform target, float value){
        RectTransform rectTransform = target.GetComponent<RectTransform>();
        Vector2 newPos = new Vector2(
            0,
            value
        );
        rectTransform.anchoredPosition = newPos;
    }
    void Update()
    {
        // SpawnLine();
    }
}
