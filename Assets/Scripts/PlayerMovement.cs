using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    // private float HSpeed = 10f;
    private float moveXInput;
    [SerializeField] private float moveSpeed = 8f;
    [SerializeField] private float jumpForce = 14f;
    public ProgressBar healthBar;
    [SerializeField] private GameObject punch;
    // 

    [SerializeField] private bool isGround = false;
    // private float groundRadius = 0.15f;



    [SerializeField] private int playerNumber;
    private SpriteRenderer sprite;
    private string playerHorizontal;
    private string playerVertical;
    public GameObject Opponent;
    private Vector2 movement;
    public Vector3 OppPos;
    public bool facingLeft = false;
    public bool facingRight = true;

    private Animator anim;

    [SerializeField] private AudioSource hitSound;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();

        isGround = true;

        for (int i = 0; i < Gamepad.all.Count; i++)
        {
            Debug.Log(Gamepad.all[i].name);
        }
    }

    void FixedUpdate()
    {

        // grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
        anim.SetBool("ground", isGround);


    }

    // Update is called once per frame
    void Update()
    {

        Move();
        moveXInput = movement.x; //Input.GetAxis("Horizontal");

        OppPos = Opponent.transform.position;

        if (OppPos.x > transform.position.x)
        {
            facingLeft = false;
            facingRight = true;
            // sprite.flipX = false;
            this.transform.localScale = new Vector3(1, 1, 1);

        }

        if (OppPos.x < transform.position.x)
        {
            facingLeft = true;
            facingRight = false;
            this.transform.localScale = new Vector3(-1, 1, 1);

        }

        anim.SetFloat("HSpeed", Mathf.Abs(moveXInput));
        anim.SetFloat("vSpeed", GetComponent<Rigidbody2D>().velocity.y);

    }

    void Move()
    {

        rb.velocity = new Vector2(movement.x * moveSpeed, rb.velocity.y);
    }
    void Jump()
    {
        if (isGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            anim.SetBool("ground", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Floor"))
        {
            isGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Floor"))
        {
            isGround = false;
        }
    }

    public void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }

    public void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            Jump();
            // rb.velocity = new Vector2(movement.x * moveSpeed, jumpForce);

        }
    }

    public void OnPunch(InputValue value)
    {
        anim.SetTrigger("Punch");
        if (isGround)
        {
            hitSound.Play();
        }
    }

    public void PunchOn()
    {
        punch.SetActive(true);
    }

    public void PunchOff()
    {
        punch.SetActive(false);
    }

}
