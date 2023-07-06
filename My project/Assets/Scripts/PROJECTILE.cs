using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PROJECTILE : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private Vector3 temp;

    private void Update()
    {
        transform.position += transform.right * Time.deltaTime * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Stops if it hits a wall or something
        if (!collision.gameObject.CompareTag("Player"))
        {
            speed = 0;
        }
       

        //Gets destoryed when picked up by player
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);

        }        
    }

}