using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{

    public float health;
    public float enemy_level;
    public float speed;

    public int duration;

    public GameObject player;
    [SerializeField] Rigidbody2D rb;

    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        health = health * enemy_level;

        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        
        rb.position = Vector2.MoveTowards(transform.position, player.transform.position,speed * 1f);
    }
}
    