using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    public static float speed = 3f;
    public int lives = 5;
    public float jumpForce = 15f;

    float moveHorizontal;
    float moveVertical;

    public Animator animator;
    public Joystick joystick;

    public Rigidbody2D rb;
    private SpriteRenderer sprite;

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

        FlipX();
        
    }

    void FixedUpdate()
    {
        MovementLogic();
        //JumpLogic();
        
    }

    private void FlipX(){
        
        if(joystick.Horizontal < 0){
            GetComponentInChildren<SpriteRenderer>().flipX = true;
        }
        else if(joystick.Horizontal > 0){
            GetComponentInChildren<SpriteRenderer>().flipX = false;
        }

    }

    // Передвижение
    private void MovementLogic()
    {

        moveHorizontal = joystick.Horizontal;
        moveVertical = joystick.Vertical;

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);
        transform.Translate(movement * speed * Time.fixedDeltaTime);

    }

    // Прыжок
    private void Jump(){

        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);

    }

    // Получение урона
    public void GetDamage(){
        lives -= 1;
        Debug.Log(lives);
        
        StartCoroutine(visualDamage());
    }

    public IEnumerator visualDamage(){

        sprite.color = new Color(1.0f, 0.503f, 0.503f);
        yield return new WaitForSeconds(0.5f); 
        sprite.color = new Color(1.0f, 1.0f, 1.0f);  

    }

    
    

    

}
