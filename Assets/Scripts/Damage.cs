using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision){

        if (collision.gameObject == PlayerController.Instance.gameObject){
            PlayerController.Instance.GetDamage();
        }

    }

    // Запуск скрипта
    void Start()
    {
        
    }

    // Каждый кадр
    void Update()
    {
        
    }
}
