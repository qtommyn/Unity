﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{

    public float Speed = 10;
    public int Health = 3;

    private GameObject Player;

    private void Start()
    {
        //Player player = FindObjectOfType<Player>();
        //player.gameObject
        Player = FindObjectOfType<Player>().gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, 
            Player.transform.position, 
            Speed * Time.deltaTime);
        //gameObject
        // A changer 3e argument, pour que le monstre regarde vers le joueur
        // transform.LookAt(Player.transform.position, Vector3);
        transform.right = Player.transform.position - transform.position;
    }

    public void onBulletCollision(Bullet bullet)
    {
        Health = Health - 1;

        if (Health < 1)
        {
            Debug.Log("Enemy is dead");
            Destroy(gameObject);
        }


        Debug.Log("Health: " + Health);
    }
}