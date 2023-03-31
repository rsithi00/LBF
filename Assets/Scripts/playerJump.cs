using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerJump : MonoBehaviour
{
  private Rigidbody2D rb;
  public float jump;

  private bool isGround;
    // Start is called before the first frame update
    void Start()
    {
      rb = GetComponent<Rigidbody2D>();
      isGround = true;
    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetButtonDown("Jump") && isGround){
        rb.velocity = new Vector2(rb.velocity.x, jump);
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
