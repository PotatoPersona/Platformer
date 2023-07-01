using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float speed = 10;
    public float jump = 10;
    private float moveInput;

    private Rigidbody2D rb;
    private bool facingRight = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpsValue;

    void Start()
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //Chekcs if player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

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

        //Allows the player to jump
        if (isGrounded == true)
        {
            extraJumps = extraJumpsValue;
        }

        if (Input.GetAxis("Vertical") > 0 && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jump;
            extraJumps--;
        }

        else if (Input.GetAxis("Vertical") > 0 && extraJumps == 0 && isGrounded == true)
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
    }