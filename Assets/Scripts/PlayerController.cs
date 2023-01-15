using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    public static float speed = 6f;
    public int lives = 5;
    public float jumpForce = 15f;

    float moveHorizontal;
    float moveVertical;

    public Animator animator;
    public Joystick joystick;

    public Rigidbody2D rb;
    public SpriteRenderer sprite;

    public static PlayerController Instance {get; set;}

    // Запуск игры
    public void Awake(){
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        Instance = this;
    }

    // Запуск скрипта
    void Start()
    {
        
    }

    // Каждый кадр
    void Update()
    {
        animator.SetFloat("HorizontalMove", Math.Abs(moveHorizontal));

        if(Input.GetAxis("Horizontal") < 0){
            GetComponentInChildren<SpriteRenderer>().flipX = true;
        }
        if(Input.GetAxis("Horizontal") > 0){
            GetComponentInChildren<SpriteRenderer>().flipX = false;
        }
        
    }

    void FixedUpdate()
    {
        MovementLogic();
        //JumpLogic();
    }

    // Передвижение
    private void MovementLogic()
    {

        moveHorizontal = joystick.Horizontal;
        moveVertical = joystick.Vertical;

        // moveHorizontal = Input.GetAxis("Horizontal");
        // moveVertical = Input.GetAxis("Vertical");
        
        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);

        transform.Translate(movement * speed * Time.fixedDeltaTime);

        //rb.AddForce(movement * speed);
    }

    // Прыжок
    private void Jump(){

        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);

    }

    // Получение урона
    public void GetDamage(){
        lives -= 1;
        Debug.Log(lives);
    }

    

}
