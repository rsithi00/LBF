using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.InputSystem;

//This Script is intended for demoing and testing animations only.


public class bearController : MonoBehaviour {

	private float HSpeed = 10f;
	//private float maxVertHSpeed = 20f;
	private bool facingRight = true;
	private float moveXInput;

    //Used for flipping Character Direction
	public static Vector3 theScale;

	//Jumping Stuff
	public Transform groundCheck;
	public LayerMask whatIsGround;
	private bool grounded = false;
	private float groundRadius = 0.15f;
	private float jumpForce = 14f;
	

	private Animator anim;

	private Rigidbody2D rb;
	public Vector3 OppPos;
	public GameObject Opponent;
    public bool facingLeft = false;
	private SpriteRenderer sprite;
	private Vector2 movement;
    // public bool facingRight = true;

	// Use this for initialization
	void Awake ()
	{
//		startTime = Time.time;
		anim = GetComponent<Animator> ();
		sprite = GetComponent<SpriteRenderer>();
		rb = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate ()
	{

		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool ("ground", grounded);


	}

	void Update()
	{
		Move();

		OppPos = Opponent.transform.position;

        if(OppPos.x > transform.position.x)
        {
            facingLeft = false;
            facingRight = true;
            sprite.flipX = false;
        }

        if (OppPos.x < transform.position.x)
        {
            facingLeft = true;
            facingRight = false;            
            sprite.flipX = true;
        }

        moveXInput = Input.GetAxis("Horizontal");

        if ((grounded) && Input.GetButtonDown("Jump"))
        {
            anim.SetBool("ground", false);

            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.y, jumpForce);
        }


        anim.SetFloat("HSpeed", Mathf.Abs(moveXInput));
        anim.SetFloat("vSpeed", GetComponent<Rigidbody2D>().velocity.y);


        GetComponent<Rigidbody2D>().velocity = new Vector2((moveXInput * HSpeed), GetComponent<Rigidbody2D>().velocity.y);

        if (Input.GetButtonDown("Fire1") && (grounded)) 
		{ 
			anim.SetTrigger("Punch"); 

		}

        if (Input.GetButton("Fire2"))
        {
            anim.SetBool("Sprint", true);
            HSpeed = 14f;
}
        else
        {
            anim.SetBool("Sprint", false);
            HSpeed = 10f;
        }

        //Flipping direction character is facing based on players Input
        // if (moveXInput > 0 && !facingRight)
        //     Flip();
        // else if (moveXInput < 0 && facingRight)
        //     Flip();
    }
    ////Flipping direction of character
    void Flip()
	{
		facingRight = !facingRight;
		theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	    public void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }

    public void OnJump(InputValue value) {
        if(value.isPressed)
        {
            Jump();
            // rb.velocity = new Vector2(movement.x * moveSpeed, jumpForce);
        }
    }

	void Jump()
        {
            if(grounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                anim.SetBool("ground", false);
            }
        }

	void Move()
        {

            rb.velocity = new Vector2(movement.x * HSpeed , rb.velocity.y);
        }

}
