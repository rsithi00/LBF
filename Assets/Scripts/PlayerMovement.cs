using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float jumpForce = 7f;
    private float dirX;
    [SerializeField] private float maxHealth = 100;
    [SerializeField] private GameObject hitEffect;
    private HealthBar healthbar;
    private float currentHealth;

    private bool opponentRight;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        currentHealth = maxHealth;
        healthbar.UpdateHealthBar(maxHealth, currentHealth);
    }

    void Update()
    {
        // Define horizontal movement controls
        dirX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);


        if (opponentRight)
        {
            sprite.flipX = false;
        }
        else
        {
            sprite.flipX = true;
        }


        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        currentHealth -= GetHit();
        if (currentHealth <= 0)
        {
            // deathscript
        }
        else
        {
            healthbar.UpdateHealthBar(maxHealth, currentHealth);
            Instantiate(hitEffect, transform.position,Quaternion.identity);
        }


    }

    private bool GetOpponentSide(int player)
    {
        bool side = true;
        if (player == 2)
            side = false;

        return side;
    }

    private float GetHit()
    {
        float hit = 10;
        return hit;
    }
}
