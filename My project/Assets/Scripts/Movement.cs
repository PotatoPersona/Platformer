using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] private float speed = 10;
    [SerializeField] private float jump = 10;
    private float moveInput;
    private bool facingRight = true;

    private Rigidbody2D rb;
    private BoxCollider2D coll;
    [SerializeField] private LayerMask jumpableGround;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
    }

    void FixedUpdate()
    {
        //Allows for horizontal movement
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }
    }

    private void Update()
    {
        //Lets the Player Jump
        if (Input.GetAxis("Vertical") > 0 && isGrounded())
        {
            rb.velocity = Vector2.up * jump;
        }
    }

    //Flips the objects direction
    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    //Checks if player is on the ground
    private bool isGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}