using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class player_shooting : MonoBehaviour
{

    public Transform player;
    public static Transform weapon;

    public float get_cooldown;

    private bool canshoot = true;

    private Vector2 direction; 

    public bool active;

    private weapon_manager weapon_manager;

    void FixedUpdate()
    {
        
        Vector3 mouse_position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = (mouse_position - transform.position).normalized;
    }
    
    void Update()
    {

        if(weapon != null)
        {

            gun g = weapon.GetComponent<gun>();

            if (!g.fast && Input.GetMouseButtonDown(0) && active && canshoot)
            {

                SHOOT();
                get_cooldown = g.cooldown;
                StartCoroutine(Cooldown(get_cooldown));
            }

            if (g.fast && Input.GetMouseButton(0) && active)
            {

                SHOOT();
            }

            
        }
    }

    public void SHOOT()
    {

        gun g = weapon.GetComponent<gun>();

        GameObject bullet = Instantiate(g.bullet, weapon.position, weapon.rotation);
        bullet_controller bc = bullet.GetComponent<bullet_controller>();
        bc.direction = direction;

        Rigidbody2D prb = player.GetComponent<Rigidbody2D>();
        prb.AddForce(direction * g.recoil * 100f, ForceMode2D.Impulse);
    }

    public IEnumerator Cooldown(float cooldown)
    {
        canshoot = false;
        yield return new WaitForSeconds(cooldown);
        canshoot = true;
    }

}
