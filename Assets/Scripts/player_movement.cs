using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{

    public float speed;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Vector2 move_direction;

    private void Awake()
    {

        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        ProcessInputs();
    }

    void FixedUpdate()
    {

        Move();

        if(move_direction.x == 1)
        {


            Quaternion newRotation =  Quaternion.Euler(0f, 0f, 0f);
            transform.rotation = newRotation;
        }
        else if(move_direction.x == -1)
        {

            Quaternion newRotation = Quaternion.Euler(0f, 180f, 0f);
            transform.rotation = newRotation;
        }
    }

    void ProcessInputs()
    {

        float moveX = Input.GetAxisRaw("Horizontal");   
        float moveY = Input.GetAxisRaw("Vertical");

        move_direction = new Vector2(moveX, moveY);
    }

    void Move()
    {

        rb.velocity = new Vector2(move_direction.x * speed, move_direction.y * speed);
    }
}
