using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Painting : MonoBehaviour
{


    public GameObject obj;
    private int counter = 0, counter2 = 0, maxCount = 1000;
    private bool isSave;
    public float paintStock = 1.0f;
    public Image timerBar;
    public List<GameObject> points = new List<GameObject>();


    void Start()
    {
        
    }


    void Update()
    {
        if(Input.GetMouseButton(0))
		{
            if(paintStock > 0)
            {
                Draw();
                Optimize();
            }
		}
    }

    void Draw() // рисование (клонирование кисти)
	{
		Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

        if(worldPosition[0] < -6.2f && worldPosition[1] < -1.5f)
            return;

        Debug.Log("World - " + worldPosition);


        points.Add(Instantiate(obj, worldPosition, Quaternion.identity) as GameObject);
        counter++;
        
        timerBar.fillAmount = paintStock;
        
        paintStock -= 0.005f;  
        
	}

    void Optimize(){
        // TODO: Автоудаление объектов //
        if(counter > 20 && (counter2 < points.Count)){
            Destroy(points[counter2]);
            counter2++;
        }

    }
}
