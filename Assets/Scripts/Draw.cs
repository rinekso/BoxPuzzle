using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Draw : MonoBehaviour
{
    [System.Serializable]
    public struct Dot
    {
        public string name;
        public Transform point;
    }
    public List<Dot> dots;
    private List<GameObject> objDraw;
    public float widthLine;
    public Color colorLine;
    private void Start() {
        objDraw = new List<GameObject>();
        // SpawnLine();
    }

	void OnGUI ()
	{  
		SpawnLine();
	}
    void SpawnLine(){
        for (int i = 0; i < dots.Count; i++)
        {
            GameObject go;
            if(objDraw.Count < dots.Count){
                go = new GameObject();
                go.AddComponent<RawImage>();
                go.transform.parent = transform;
                objDraw.Add(go);
            }else{
                go = objDraw[i];
            }
            if(i<dots.Count-1){
                DrawLine(dots[i].point.GetComponent<RectTransform>().position,dots[i+1].point.GetComponent<RectTransform>().position,go.GetComponent<RawImage>());
            }else{
                DrawLine(dots[i].point.GetComponent<RectTransform>().position,dots[0].point.GetComponent<RectTransform>().position,go.GetComponent<RawImage>());
            }
        }
    }

	void DrawLine (Vector2 pointA, Vector2 pointB, RawImage image)
	{        
		Texture2D lineTex = new Texture2D (1, 1);  
		float width = widthLine;
		GUI.color = colorLine;
        Vector3 intoPlane = Vector3.forward;
        Vector3 toTarget = pointA - pointB;
        image.rectTransform.rotation = Quaternion.LookRotation(intoPlane,-toTarget);
        image.rectTransform.sizeDelta = new Vector2(width,Vector2.Distance(pointA,pointB)+widthLine/2+2);
        image.rectTransform.position = Vector2.Lerp(pointA,pointB,0.5f);
        image.color = colorLine;
	}
}