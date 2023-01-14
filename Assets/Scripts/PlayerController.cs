using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
        float movementX = Input.GetAxis("Horizontal"); // -1 лево +1 право
        float movementY = Input.GetAxis("Vertical"); // -1 лево +1 право
        transform.position += new Vector3(movementX, movementY, 0) * speed * Time.deltaTime;
    }

}
