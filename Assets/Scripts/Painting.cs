using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Painting : MonoBehaviour
{


    public GameObject obj;
    private int counter = 0, maxCount = 1000;
    private bool isSave;
    public float paintStock = 1.0f;
    public Image timerBar;
    private List<GameObject> points = new List<GameObject>();

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
            }
		}
    }

    void Draw() // рисование (клонирование кисти)
	{
		Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

        Debug.Log("Screen - " + screenPosition);
        Debug.Log("World - " + worldPosition);

        points.Add(Instantiate(obj, worldPosition, Quaternion.identity) as GameObject);
        counter++;

        //NewObject.AddComponent<CircleCollider2D>();
        //NewObject.AddComponent<UnityEngine.AI.NavMeshObstacle>();
        //Debug.Log(s.GetComponent<UnityEngine.AI.NavMeshObstacle>().carve);
        //NewObject.GetComponent<SpriteRenderer>.sortingOrder = 10;
        
        timerBar.fillAmount = paintStock;

        
        paintStock -= 0.005f;
        Debug.Log("PaintStock - " + paintStock);


        // TODO: Автоудаление объектов //

        if(counter > 20){
            Destroy(points[points.Count]);
        }

        // НЕ УДАЛЯЕТ!!!!
        
	}
}
