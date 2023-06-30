using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{

    public string gun_tag;

    public Transform player;
    public GameObject bullet;

    public float cooldown;
    public float distance;
    public float recoil;

    public bool can;
    public bool fast;
    public bool multigun;

    public weapon_manager manager;

    void Start()
    {

        manager = gameObject.GetComponent<weapon_manager>();
    }

    void Update()
    {
        distance = Vector2.Distance(transform.position, player.position);

        if(distance < 0.7f ) { can = true; }
        else { can = false; }
    }
}
