using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiresGiblit : MonoBehaviour
{
    [SerializeField] private Transform LaunchOffset;
    [SerializeField] private PROJECTILE ProjectilePrefab;

    [SerializeField] private float initialHealth = 5;
    [SerializeField] private float health;

    public Animator anime;


    private Vector3 temp;

    void Start()
    {
        health = initialHealth;
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
           
            health++;
            temp.x += .1f;
            temp.y += .1f;
            temp.z += .1f;
            transform.localScale = temp;
            ProjectilePrefab.transform.localScale = temp;
            
        }




        if (collision.gameObject.CompareTag("Hurt"))
        {

            if (health >= 1)
            {
                health--;
                temp.x -= .1f;
                temp.y -= .1f;
                temp.z -= .1f;
                transform.localScale = temp;

                anime.SetTrigger("isHurt");
            }
            else if (health < 1)
            {
                anime.SetTrigger("isDead");
                Destroy(gameObject);
            }

        }
    }
}
