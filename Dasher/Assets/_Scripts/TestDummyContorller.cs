using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestDummyContorller : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;
    public static bool facingRight = true;


    private Rigidbody2D rb;
    private static bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    public int extraJumpsValue;
    private int extraJumps;

    public float hp;

    void Start()
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (facingRight == false && moveInput > 0)
        {
            flip();
            //Debug.Log(facingRight);
        }
        else if (facingRight == true && moveInput < 0)
        {
            flip();
            //Debug.Log(facingRight);
        }
    }

    void Update()
    {
        if (isGrounded)
        {
            extraJumps = 2;
        }
        if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded)
        {
            rb.velocity = Vector2.up * jumpForce;
        }

        if (hp <= 0)
        {
            Death();
        }
        if (transform.position.y < -20)
        {
            Death();
        }
        if(transform.position.x>34 & transform.position.y < -5 & SceneManager.GetActiveScene().name=="Train Scene")
        {
            SceneManager.LoadScene("Inside", LoadSceneMode.Single);
        }
        if (transform.position.x > 47 & SceneManager.GetActiveScene().name == "Inside")
        {
            SceneManager.LoadScene("Train Scene", LoadSceneMode.Single);
        }
    }

    void flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    // Method to take damage
    public void takeDamage(int damage)
    {
        // Health is equal to previous health minus damage
        hp = hp - damage;

        // If health is below 0
        if (hp <= 0.0f)
        {
            // Change state to Dying
            Death();
        }
    }

    public void Death()
    {
        Debug.Log("Dummy Destroyed");
        Destroy(gameObject);
        gameObject.SetActive(false);
    }
}
