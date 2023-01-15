using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static float speed = 6f;
    public int lives = 5;
    public float jumpForce = 15f;

    public Rigidbody2D rb;
    public SpriteRenderer sprite;

    public static PlayerController Instance {get; set;}


    public void Awake(){
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    void FixedUpdate()
    {
        MovementLogic();
        //JumpLogic();
    }

    private void MovementLogic()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);

        transform.Translate(movement * speed * Time.fixedDeltaTime);

        //rb.AddForce(movement * speed);
    }

    public void GetDamage(){
        lives -= 1;
        Debug.Log(lives);
    }

    private void Jump(){

        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);

    }

}
