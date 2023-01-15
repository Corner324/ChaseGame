using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sand : MonoBehaviour
{

    public void OnTriggerEnter2D(Collider2D collider){

        if (collider.gameObject == PlayerController.Instance.gameObject){
            PlayerController.speed = 3f;
        }
        if (collider.gameObject == EnemyController.Instance.gameObject){
            PlayerController.speed = 2f;
        }

    }

    public void OnTriggerExit2D(Collider2D collider){

        if (collider.gameObject == PlayerController.Instance.gameObject){
            PlayerController.speed = 6f;
        }
        if (collider.gameObject == EnemyController.Instance.gameObject){
            PlayerController.speed = 3f;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
