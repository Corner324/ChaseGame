using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyController : MonoBehaviour
{

    public Transform player;
    public float speed;

    public static EnemyController Instance {get; set;}



    // Запуск игры
    void Awake(){
        Instance = this;
    }

    // Запуск скрипта
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Каждый кадр
    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position,player.position, speed*Time.fixedDeltaTime);
    }

}
