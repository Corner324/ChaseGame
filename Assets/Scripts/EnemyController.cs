using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;
using System;

public class EnemyController : MonoBehaviour
{

    public Transform player;
    NavMeshAgent agent;

    public float speed;

    Vector2 startPos;
    Vector2 endPos;

    public Animator animator;
    AudioSource audioSource;

    Vector3 currentDirection;

    public static EnemyController Instance {get; set;}



    // Запуск игры
    void Awake(){
        Instance = this;
    }

    // Запуск скрипта
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Каждый кадр
    void FixedUpdate()
    {
        // transform.position = Vector2.MoveTowards(transform.position,player.position, speed*Time.fixedDeltaTime);
        
    }

    void Update(){

        agent.SetDestination(player.position);
        FlipX();

    }

    private void OnCollisionEnter2D(Collision2D collision){

        if (collision.gameObject == PlayerController.Instance.gameObject){
            PlayerController.Instance.GetDamage();
            audioSource.Play();
            
        }

    }

    private void FlipX(){

        var heading = player.position - transform.position;
        var distance = heading.magnitude;
        var direction = heading / distance; // This is now the normalized direction.

        
        if(direction[0] < 0){
            GetComponentInChildren<SpriteRenderer>().flipX = true;
        }
        else if(direction[0] > 0){
            GetComponentInChildren<SpriteRenderer>().flipX = false;
        } 

    }

}
