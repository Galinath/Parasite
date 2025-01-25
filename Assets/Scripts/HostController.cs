using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class HostController : MonoBehaviour 
 { 
   private bool isControlled = false;

    private Rigidbody2D rb;

    private float speed = 5f;

    private ParasiteController parasite;

    private bool facingRight = true;

    private int jumpCount = 0;

    private int maxJumps = 2; // Allow double jump

    public float jumpForce = 10f;



    void Start()

    {

        rb = GetComponent<Rigidbody2D>();

    }



    void Update()

    {

        if (isControlled)

        {

            float move = Input.GetAxis("Horizontal");

            rb.velocity = new Vector2(move * speed, rb.velocity.y);



            if (move > 0 && !facingRight)

                Flip();

            else if (move < 0 && facingRight)

                Flip();



            if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumps)

            {

                Jump();

            }

        }

        else

        {

            rb.velocity = Vector2.zero;

        }

    }



    void Jump()

    {

        rb.velocity = new Vector2(rb.velocity.x, jumpForce);

        jumpCount++; // Increment jump count

    }



    void OnCollisionEnter2D(Collision2D other)

    {

        if (other.gameObject.CompareTag("Ground"))

        {

            jumpCount = 0; // Reset jump count when touching the ground

        }

    }



    public void TakeControl(ParasiteController newParasite)

    {

        isControlled = true;

        parasite = newParasite;

    }



    public void ReleaseControl()

    {

        isControlled = false;

    }



    void Flip()

    {

        facingRight = !facingRight;

        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    
  } 

  }
