using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiresGiblit : MonoBehaviour
{
    public Transform LaunchOffset;
    public PROJECTILE ProjectilePrefab;

    private float maxHealth = 5;
    public float health;

    public GameObject player;
    public Vector3 temp;

    void Start()
    {
        health = maxHealth;
        temp = player.transform.localScale;
    }

    void Update()
    {
       /*
        if (Input.GetButtonDown("Fire1") && health > 0)
        {
            Instantiate(ProjectilePrefab, LaunchOffset.position, transform.rotation);
            health--;
            temp.x -= .1f;
            temp.y -= .1f;
            temp.z -= .1f;
            player.transform.localScale = temp;
        }
       */
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Giblit" && collision.gameObject.tag == "Player")
        {
            if (health < maxHealth)
            {
                health++;
                temp.x += .1f;
                temp.y += .1f;
                temp.z += .1f;
                player.transform.localScale = temp;
            }

        }
    }
}
