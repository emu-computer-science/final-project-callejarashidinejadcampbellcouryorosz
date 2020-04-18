using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Enemy Behavior Class
public class Enemy_behavior : MonoBehaviour
{
    // Public Variables
    #region Public Variables
    public Transform rayCast;       // The Raycast GameObject
    public LayerMask raycastMask;   // The Layer we're trying to detect
    public float rayCastLength;
    public float attackDistance;    // Minimum distance for attack
    public float moveSpeed;         // Movement Speed
    public float timer;             // Timer Cooldown between attacks
    #endregion

    // Private Variables
    #region Private Variables
    private RaycastHit2D hit;       // The Raycast when it hits the player
    private GameObject target;      // The Player GameObject
    private Animator anim;
    private float distance;         // Store the distance between enemy and player
    public static bool attackMode;        // Boolean, if it's attacking or not
    private bool inRange;           // Check if Player is in range
    private bool cooling;           // Check if Enemy is cooling down after attack
    private float intTimer;
    #endregion

    // Awake initializes any variables before the game starts
    private void Awake()
    {
        intTimer = timer;                   // Store the inital value of the timer
        anim = GetComponent<Animator>();    // Taking the Animator component and storing it in 'anim'
    }

    // Update Method
    void Update()
    {

        // If the player is in range
        if (inRange == true)
        {
            // Shoot a raycast and store the information into the hit variable
            hit = Physics2D.Raycast(rayCast.position, Vector2.left, rayCastLength, raycastMask);

            // Calling our Raycast Debugger
            RaycastDebugger();
        }

        if (target != null)
        {
            // If the Target is to the right of the enemy
            if (target.transform.position.x > transform.position.x)
            {
                // Turn Toward the Target
                transform.eulerAngles = new Vector3(0, -180, 0);
                hit = Physics2D.Raycast(rayCast.position, Vector2.right, rayCastLength, raycastMask);
            }
            else
            {
                // Turn Toward the Target
                transform.eulerAngles = new Vector3(0, 0, 0);
                hit = Physics2D.Raycast(rayCast.position, Vector2.left, rayCastLength, raycastMask);
            }
        }

        // If the player is detected
        if (hit.collider != null)
        {
            // Call Enemy Logic
            EnemyLogic();
        }
        // Else If the hit is nothing
        else if (hit.collider == null)
        {
            // The Player isn't in range
            inRange = false;
        }

        // If the Player isn't in Range
        if (inRange == false)
        {
            // Stop the Walking Animation
            anim.SetBool("canWalk", false);

            // Stop the Attack
            StopAttack();
        }
    }

    // Method is Trigger upon a collision
    private void OnTriggerEnter2D(Collider2D trig)
    {
        // If the Collision was caused by the Player
        if (trig.gameObject.tag == "Player")
        {
            // The Target is the Player
            target = trig.gameObject;

            // The Player is inRange
            inRange = true;
        }
    }

    // Enemy Logic Method
    void EnemyLogic()
    {
        // The Distance is equal to the distance between the enemy and player
        distance = Vector2.Distance(transform.position, target.transform.position);

        // If distance is greater than attack distance
        if (distance > attackDistance)
        {
            // Calling Move Method
            Move();

            // Calling Stop Attack Function
            StopAttack();
        }
        // Else If the attack distance is equal or greater than the distance and the cooldown is over or not active
        else if (attackDistance >= distance && cooling == false)
        {
            Attack();
        }
        // If the enemy is cooling down
        else if (cooling == true)
        {
            // Calling Cooldown
            Cooldown();

            // Stop the Attack Animation
            anim.SetBool("Attack", false);
        }
    }

    // Move Method
    void Move()
    {
        // Set Walking Animation to True
        anim.SetBool("canWalk", true);

        // If we're not doing the attack animation
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Attack_Basic_Enemy") && !anim.GetCurrentAnimatorStateInfo(0).IsName("Idle_Basic_Enemy"))
        {
            // Getting Target's Position
            // We only take it's x position, we don't need it's y. So we're using the Enemies
            Vector2 targetPosition = new Vector2(target.transform.position.x, transform.position.y);

            // Start Moving Toward the Player
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }

    // Attack Method
    void Attack()
    {
        timer = intTimer;               // Reset Timer when Player enter Attack Range
        attackMode = true;              // To check if Enemy can still attack or not

        anim.SetBool("canWalk", false); // Setting Walk to False
        anim.SetBool("Attack", true);   // Setting Attack to true

    }

    // Stop Attack Method
    void StopAttack()
    {
        cooling = false;                // Cooldown is false
        attackMode = false;             // Attack Mode is false
        anim.SetBool("Attack", false);  // Attack Animation Stops
    }

    // Method to show the Raycast in the scene to make debugging easier
    void RaycastDebugger()
    {
        // If the distance between the enemy and the player is greater than the attack distance
        if (distance > attackDistance)
        {

            // If the Target is to the right of the enemy
            if (target.transform.position.x > transform.position.x)
            {
                // Make the ray red (right)
                Debug.DrawRay(rayCast.position, Vector2.right * rayCastLength, Color.red);
            }
            else
            {
                // Make the ray red (left)
                Debug.DrawRay(rayCast.position, Vector2.left * rayCastLength, Color.red);
            }
        }
        // If the attack distance is greater than the distance between the enemy and the player
        else if (attackDistance > distance)
        {
            // If the Target is to the right of the enemy
            if (target.transform.position.x > transform.position.x)
            {
                // Make the ray red (right)
                Debug.DrawRay(rayCast.position, Vector2.right * rayCastLength, Color.green);
            }
            else
            {
                // Make the ray red (left)
                Debug.DrawRay(rayCast.position, Vector2.left * rayCastLength, Color.green);
            }
        }
    }

    // Cooldown on Attack Method
    void Cooldown()
    {
        // Timer - Time Passed
        timer -= Time.deltaTime;

        // If the Timer is less than 0 & cooling is true & attackMode is true
        if (timer <= 0 && cooling == true && attackMode == true)
        {
            // Cooldown is False
            cooling = false;

            // Reset Timer
            timer = intTimer;
        }
    }

    // Trigger the Cooling Method
    public void TriggerCooling()
    {
        cooling = true;
    }
}
