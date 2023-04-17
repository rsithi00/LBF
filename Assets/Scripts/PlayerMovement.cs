using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
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


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        isGround = true;
        if (playerNumber == 1)
        {
            playerHorizontal = "Horizontal";
            playerVertical = "Vertical";
        }
        else
        {
            playerHorizontal = "HorizontalP2";
            playerVertical = "VerticalP2";
        }

    }

    // Update is called once per frame
    void Update()
    {


        float dirX = Input.GetAxis(playerHorizontal);
        rb.velocity = new Vector2(dirX * moveSpeed , rb.velocity.y);

        if(dirX > 0f)
        {
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            sprite.flipX = true;
        }

        if(Input.GetKeyDown(KeyCode.UpArrow) && isGround)
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
}
