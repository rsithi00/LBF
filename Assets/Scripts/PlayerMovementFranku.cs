using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementFranku : MonoBehaviour
{

    private Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 8f;
    [SerializeField] private float jumpForce = 10f;
    public ProgressBar healthBar;

    [SerializeField] private bool isGround;


    [SerializeField] private int playerNumber;
    private SpriteRenderer sprite;
    private string playerHorizontal;
    private string playerVertical;
    public GameObject Opponent;
    private Vector2 movement;
    public Vector3 OppPos;
    public bool facingLeft = false;
    public bool facingRight = true;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        isGround = true;

        if(playerNumber == 1)
        {
            sprite.flipX = false;
        }
        else if(playerNumber == 2)
        {
            sprite.flipX = false;
        }
        
    }

    // Update is called once per frame
    void Update()
    {

        Move();

        OppPos = Opponent.transform.position;

        if(OppPos.x > transform.position.x)
        {
            facingLeft = false;
            facingRight = true;
            sprite.flipX = true;
        }

        if (OppPos.x < transform.position.x)
        {
            facingLeft = true;
            facingRight = false;            
            sprite.flipX = false;
        }

    }

        void Move()
        {

            rb.velocity = new Vector2(movement.x * moveSpeed , rb.velocity.y);
        }
        void Jump()
        {
            if(isGround)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }

        private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Floor"))
        {
            isGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Floor"))
        {
            isGround = false;
        }
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

}
