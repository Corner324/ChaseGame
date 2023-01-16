using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{

    
    AudioSource audioSource;

    private void OnCollisionEnter2D(Collision2D collision){

        if (collision.gameObject == PlayerController.Instance.gameObject){
            PlayerController.Instance.GetDamage();
            audioSource.Play();
            
        }

    }

    // Запуск скрипта
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Каждый кадр
    void Update()
    {
        
    }
}
