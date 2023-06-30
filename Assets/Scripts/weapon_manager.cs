using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon_manager : MonoBehaviour
{

    [SerializeField] player_shooting ps;
    public gun gun_;

    public Transform weapon;
    public Transform player;

    public static bool weapon_equip;

    public float max_distance = 1f;

    public bool can;

    public Collider2D to_pick_up;

    void Start()
    {

        ps = GetComponent<player_shooting>();
    }

    void Update()
    {

        if (ps != null)
        {

            if (weapon_equip == true)
            {

                ps.active = true;
            }
            else
            {

                ps.active = false;
            }
        }

        if(Input.GetKeyUp(KeyCode.F))
        {

            drop();
        }

        if(can == true && weapon == null)
        {

            equip(to_pick_up);
        }
    }

    private void FixedUpdate()
    {

        Vector3 mouse_position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouse_position.z = 0f;

        Vector3 direction = mouse_position - player.position;

        if(weapon != null)
        {

            weapon.position = Vector2.MoveTowards(transform.position, direction, Time.deltaTime);

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            weapon.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    public void equip(Collider2D collision)
    {

        if (Input.GetKeyDown(KeyCode.E))
        {

            player_shooting.weapon = collision.transform;

            weapon = collision.transform;
            weapon_equip = true;
            ps.active = true;

            gun_ = collision.GetComponent<gun>();
        }
    }

    public void drop()
    {

        player_shooting.weapon = null;

        ps.active = false;
        Vector3 target_position = new Vector3(1f, 1f, 0f);

        if(weapon != null)
        {

            weapon.position = player.position + target_position;
        }

        weapon = null;
        weapon_equip = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "weapon")
        {

            can = true;
            to_pick_up = collision;
        }
        else
        {

            can = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.tag == "weapon")
        {

            can = false;
            to_pick_up = null;
        }
    }
}
    