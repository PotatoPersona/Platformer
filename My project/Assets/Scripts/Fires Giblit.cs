using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiresGiblit : MonoBehaviour
{
    public Transform LaunchOffset;
    public PROJECTILE ProjectilePrefab;

    private float maxHealth = 5;
    public float health;

    public Vector3 temp;

    void Start()
    {
        health = maxHealth;
        temp = transform.localScale;
    }

    void Update()
    {
       //Fires giblit and becomes smaller
        if (Input.GetButtonDown("Fire1") && health > 0)
        {
            Instantiate(ProjectilePrefab, LaunchOffset.position, transform.rotation);
            health--;
            temp.x -= .1f;
            temp.y -= .1f;
            temp.z -= .1f;
            transform.localScale = temp;
        }
       
    }

    //Picks up giblit and becomes bigger
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Giblit")
        {
            if (health < maxHealth)
            {
                health++;
                temp.x += .1f;
                temp.y += .1f;
                temp.z += .1f;
                transform.localScale = temp;
            }
        }

    }
}
