using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PROJECTILE : MonoBehaviour
{
    public float speed = 5f;

    private void Update()
    {
        transform.position += transform.right * Time.deltaTime * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        speed = 0;
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);

        }
        
    }


}