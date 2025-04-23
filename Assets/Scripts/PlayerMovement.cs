using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public bool isGrounded;
    private Rigidbody2D rb;
    public int health = 3;
    public float damageCooldown = 1.5f;
    private float lastDamageTime = -Mathf.Infinity;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            Debug.LogError("Player RB not found");
        }
    }

    private void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = 5f * 2f;
        }

        else
        {
            moveSpeed = 5f;
        }

            float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        if (Input.GetAxis("Jump") > 0 && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    public void TakeDamage(int damageValue)
    {
        if (Time.time - damageCooldown >= lastDamageTime)
        {
            lastDamageTime = Time.time;

            health -= damageValue;
            Debug.Log("Health = " + health);

            if (health <= 0)
            {
                Destroy(gameObject);
                Debug.Log("You Died!");
            }
        }
    }

    public void Bounce()
    {
        rb.velocity = new Vector2(rb.velocity.x, 5f);
    }
}