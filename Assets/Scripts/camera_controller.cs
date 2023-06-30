using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_controller : MonoBehaviour
{

    [SerializeField] Rigidbody2D rb;
    public Transform target;
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {

        rb.position = Vector2.MoveTowards(transform.position, target.position, 2.5f);
    }
}
