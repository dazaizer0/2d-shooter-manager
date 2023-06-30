using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_controller : MonoBehaviour
{
    
    public Vector2 direction;

    public float speed;
    public float damage = 1;
    public float random_dir_value = 0.04f;

    Rigidbody2D rb;
    BoxCollider2D boxCollider;

    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();

        Vector2 random_direction = new Vector2(Random.Range(direction.x -random_dir_value, direction.x +random_dir_value), Random.Range(direction.y -random_dir_value, direction.y + random_dir_value));

        boxCollider.isTrigger = true;
        rb.AddForce(random_direction * speed, ForceMode2D.Impulse);
    }

    void Update()
    {
        
        Destroy(gameObject, 5.5f);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        boxCollider.isTrigger = false;
    }
}
