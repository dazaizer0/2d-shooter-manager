using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class to_destroy : MonoBehaviour
{

    public float health;
    enemy en;

    private void Start()
    {

        en = GetComponent<enemy>();

        if (en != null)
        {

            health = en.health;
        }
    }

    void Update()
    {

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bullet_controller bc = collision.GetComponent<bullet_controller>();

        if(collision.tag == "bullet")
        {
            health -= bc.damage;
        }
    }
}
