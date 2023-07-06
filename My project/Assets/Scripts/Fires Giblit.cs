using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiresGiblit : MonoBehaviour
{
    [SerializeField] private Transform LaunchOffset;
    [SerializeField] private PROJECTILE ProjectilePrefab;

    [SerializeField] private float maxHealth = 5;
    [SerializeField] private float health;

    private Vector3 temp;

    void Start()
    {
        health = maxHealth;
        temp = transform.localScale;
    }

    void Update()
    {
       //Fires giblit and becomes smaller
        if (Input.GetButtonDown("Fire1") && health > 1)
        {
            Instantiate(ProjectilePrefab, LaunchOffset.position, transform.rotation);
            health--;
            temp.x -= .1f;
            temp.y -= .1f;
            temp.z -= .1f;
            transform.localScale = temp;
            ProjectilePrefab.transform.localScale = temp;
        }
       
    }

    //Picks up giblit and becomes bigger
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Giblit"))
        {
            if (health < maxHealth)
            {
                health++;
                temp.x += .1f;
                temp.y += .1f;
                temp.z += .1f;
                transform.localScale = temp;
                ProjectilePrefab.transform.localScale = temp;
            }
        }

    }
}
