using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public bool isGrounded;
    private Rigidbody2D rb;
    public int health = 3;
    public float damageCooldown = 1.5f;
    private float lastDamageTime = -Mathf.Infinity;
    public TextMeshProUGUI healthText;
    public AudioClip jumpSound;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            Debug.LogError("Player RB not found");
        }

        healthText.text = "Health = " + health;
    }

    private void FixedUpdate()
    {

        if(GameManager.Instance.isPaused)
        {
            return;
        }

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
            AudioSource.PlayClipAtPoint(jumpSound, transform.position, 1f);
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
            healthText.text = "Health = " + health;
            Debug.Log("Health = " + health);

            if (health <= 0)
            {
                SceneManager.LoadScene("GameOverScene");
               // Destroy(gameObject);
                Debug.Log("You Died!");
            }
        }
    }

    public void Bounce()
    {
        rb.velocity = new Vector2(rb.velocity.x, 5f);
    }
}