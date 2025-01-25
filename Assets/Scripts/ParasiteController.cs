using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParasiteController : MonoBehaviour
{
    private Rigidbody2D rb;

    private bool isPossessing = false;

    private GameObject currentHost;



    public float moveSpeed = 5f;

    public float jumpForce = 10f;

    private float possessionCooldown = 0.5f;

    private float lastDetachTime;

    private bool facingRight = true;

    private bool canJump = true; // Track if parasite can jump



    void Start()

    {

        rb = GetComponent<Rigidbody2D>();

    }



    void Update()

    {

        if (!isPossessing)

        {

            Move();

            if (Input.GetKeyDown(KeyCode.Space) && canJump)

            {

                Jump();

            }

        }

        else if (Input.GetKeyDown(KeyCode.E))

        {

            ReleaseHost();

        }

    }



    void Move()

    {

        float move = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);



        if (move > 0 && !facingRight)

            Flip();

        else if (move < 0 && facingRight)

            Flip();

    }



    void Jump()

    {

        rb.velocity = new Vector2(rb.velocity.x, jumpForce);

        canJump = false; // Disable further jumps

    }



    void OnCollisionEnter2D(Collision2D other)

    {

        if (other.gameObject.CompareTag("Ground"))

        {

            canJump = true; // Reset jump when touching the ground

        }



        if (other.gameObject.CompareTag("Host") && !isPossessing && Time.time > lastDetachTime + possessionCooldown)

        {

            PossessHost(other.gameObject);

        }

    }



    void PossessHost(GameObject host)

{

    isPossessing = true;

    currentHost = host;



    GetComponent<SpriteRenderer>().enabled = false;

    GetComponent<Collider2D>().enabled = false;

    rb.simulated = false;



    currentHost.GetComponent<HostController>().TakeControl(this);



    // Update the camera to follow the host

    Camera.main.GetComponent<CameraFollow>().SetTarget(currentHost.transform);

}



public void ReleaseHost()

{

    if (!isPossessing) return;



    isPossessing = false;

    lastDetachTime = Time.time;



    GetComponent<SpriteRenderer>().enabled = true;

    GetComponent<Collider2D>().enabled = true;

    rb.simulated = true;



    transform.position = currentHost.transform.position;

    currentHost.GetComponent<HostController>().ReleaseControl();

    currentHost = null;



    // Update the camera to follow the parasite again

    Camera.main.GetComponent<CameraFollow>().SetTarget(transform);

}



    void Flip()

    {

        facingRight = !facingRight;

        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);

    }

}