using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public PROJECTILE ProjectilePrefab;
    public Transform LaunchOffset;
    private float maxHealth = 5;
    public float health;

    
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

    private Vector3 temp;

    void Start()
    {
       health = maxHealth;
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

        if(facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if(facingRight == true && moveInput < 0)
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


        //Fires slime giblits and becomes smaller
        temp = transform.localScale;

        if (Input.GetButtonDown("Fire1") && health > 0)
        {
            Instantiate(ProjectilePrefab, LaunchOffset.position, transform.rotation);
            //giblet.firesGiblet();
            health--;
            temp.x -= .1f;
            temp.y -= .1f;
            temp.z -= .1f;
            transform.localScale = temp;
        }
        
    }

    //Gains Health when collecting giblits and becomes bigger
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
 
 


    //Flips the objects direction
    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}

