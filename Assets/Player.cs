﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject Bullet; // Drag my Explosion prefab in Unity
    public Transform BulletSpawnPoint;
    public Health Health { get; private set; } // Une property en C#
    public Flash Flash { get; private set; }
    private bool isInvincible = false;



    // Taper profull tab+tab ou propg tab+tab pour en creer une
    //private int myVar;
    //public int MyProperty
    //{
    //    get { 
    //        if (myVar == null)
    //        return myVar; }
    //    set { myVar = value; }
    //}


    public void Awake()
    {
        Health = GetComponent<Health>(); // Chercher l'instance dans le GameObject
        Flash = GetComponent<Flash>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            var bulletRotation = transform.rotation * Quaternion.Euler(0, 0, 0);

            Instantiate(Bullet, BulletSpawnPoint.position, bulletRotation);
        }

        if (Input.GetButtonDown("Fire2"))
        {

            var bulletRotation1 = transform.rotation * Quaternion.Euler(0, 0, 0);       // Se dirige tout droit
            var bulletRotation2 = transform.rotation * Quaternion.Euler(330, 0, -330);  // Se dirige en diagonale en haut
            var bulletRotation3 = transform.rotation * Quaternion.Euler(30, 0, -30);    // Se dirige en diagonale en bas

            // Fait apparaitre les Bullets a partir de leur spawn point
            Instantiate(Bullet, BulletSpawnPoint.position, bulletRotation1);
            Instantiate(Bullet, BulletSpawnPoint.position, bulletRotation2);
            Instantiate(Bullet, BulletSpawnPoint.position, bulletRotation3);
        }

        if (Flash.enabled)
        {
            isInvincible = true;
        }
        else
        {
            isInvincible = false;
        }
    }

    // OnTriggerStay2D(Collider2D collider)afin de pouvoir se faire frapper immédiatement lorsque l’invincibilité se termine.
    private void OnTriggerStay2D(Collider2D collision)
    {

        // L'objet qui est maintenant reçu en collision est maintenant le MonsterHitbox,
        // au lieu du Monster qui ne contient pas de script Enemy. 
        // Il faut plutôt faire, qui va rechercher dans son parent 
        var enemy = collision.gameObject.GetComponentInParent<Monster>(); 
        
        if (enemy != null && isInvincible == false)
        {
            Health.Quantity = Health.Quantity - 1;
            Flash.StartFlash();

            Debug.Log("Player Health: " + Health.Quantity);
        }
    }
}