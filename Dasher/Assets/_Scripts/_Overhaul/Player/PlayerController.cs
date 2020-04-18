using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// PlayerController Class
public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb;             // Rigidbody2D for our player
    private Animator anim;              // Animator for our player

    #region
    // Public Variables
    public float moveSpd;               // Movement Speed
    public float jumpForce;             // Jump Force 
    public bool isGrounded = false;     // This prevents infinite jumping
    #endregion

    #region
    // Private Variables
    private float movementInputDirection;           // Storing the direction of the player
    private bool isFacingRight = true;              // Direction of the Player
    private bool isWalking;                         // Is the player walking?
    private bool isJumping;                         // Is the player jumping?
    #endregion

    // Start Method
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();           // Assigning the Rigidbody2D Component to rb
        anim = GetComponent<Animator>();            // Assigning the Animator Component to anim
    }

    // Update Method
    void Update()
    { 
        CheckInput();           // Call CheckInput
        CheckMoveDirection();   // Call CheckMoveDirection
        UpdateAnimations();     // Call UpdateAnimations
        CheckScene();           //checks to see if scene needs transitioning.
    }

    // Fixed Update Method
    private void FixedUpdate()
    {
        ApplyMovement();        // Apply the Movement
    }

    // Method to Check Direction
    private void CheckMoveDirection()
    {
   
        if(isFacingRight == true && movementInputDirection < 0)     // If the Player is facing right
        {
            Flip();             // Flip the Player
        }
        else if(!isFacingRight && movementInputDirection > 0)       // If the Player is facing left
        {
            Flip();             // Flip the Player
        }
        
        if(rb.velocity.x != 0)  // If the Player is moving
        {
            // Walking is True
            isWalking = true;
        }
        else
        {
            // Else, walking is false
            isWalking = false;
        }

        if (rb.velocity.y != 0)  // If the Player is Jumping
        {
            // Jumping is True
            isJumping = true;
        }
        else
        {
            // Else, Jumping is false
            isJumping = false;
        }
    }

    // Method to Update Animations for Player
    private void UpdateAnimations()
    {
        anim.SetBool("isWalking", isWalking);
        anim.SetBool("isJumping", isJumping);
    }

    // Method to Check for Input
    private void CheckInput()
    {
        // This determine whether the player is pressing "a" or "d"
            // Returns -1 if it's "a" and returns 1 if it's "d"
                // If it was Input.GetAxis, it would return a number between 0 and -1, and 0 and 1
        movementInputDirection = Input.GetAxisRaw("Horizontal");

        // If they press jump
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            // Then Jump
            Jump();
        }
    }

    // Jump Method
    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    // Method to Apply the Movement
    private void ApplyMovement()
    {
        // This takes the movement speed and multiplies it with the direction, moving the rigidbody2D in that y direction
        rb.velocity = new Vector2(moveSpd * movementInputDirection, rb.velocity.y);
    }

    // Method to Flip the Player
    private void Flip()
    {
        isFacingRight = !isFacingRight;         // This will automatically switch to the other side
        transform.Rotate(0.0f, 180.0f, 0.0f);   // Rotate the Player in 180 degrees
    }
    private void CheckScene()
    {
        if (GameObject.FindGameObjectWithTag("Player").transform.position.x > 81 && isGrounded && SceneManager.GetActiveScene().name == "Overhaul_Player")
        {
            SceneManager.LoadScene("Train_Inside", LoadSceneMode.Single);
        }
        if (GameObject.FindGameObjectWithTag("Player").transform.position.y > 3 && SceneManager.GetActiveScene().name == "Train_Inside")
        {
            SceneManager.LoadScene("Overhaul_Player", LoadSceneMode.Single);
        }
    }
}
