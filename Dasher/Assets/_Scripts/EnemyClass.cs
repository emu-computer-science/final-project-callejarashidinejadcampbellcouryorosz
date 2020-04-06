using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is the Basic Enemy Class
<<<<<<< HEAD
    // We're looking to apply this to multiple different types of enemies
public class EnemyClass : MonoBehaviour
{

    // Different States of the Enemy
    public enum State
    {
        // Idle Mode
        Idle,
        // Attack Mode
        Attacking,
        // Dying Mode
        Dying
    }

=======
// We're looking to apply this to multiple different types of enemies
public class EnemyClass : MonoBehaviour
{

>>>>>>> PlayerMovement
    // Basic Attributes
    public float hp;
    public float dmg;
    public float spd;
<<<<<<< HEAD
    public float attSpd;
    public bool isRanged;

    // Waypoint Array Object
        // This is directing the path for our Enemy AI
=======

    // Waypoint Array Object
    // This is directing the path for our Enemy AI
>>>>>>> PlayerMovement
    Waypoint wPoints;

    // Waypoint Index
    int wpIndex;

    // The Player Target
<<<<<<< HEAD
        // This is the direction of the player
    GameObject target;

    // The State of the Enemy
    public State state;

    // Is the Enemy Attacking?
    bool isAttack;
=======
    // This is the direction of the player
    public Transform target;
>>>>>>> PlayerMovement

    // Start Method
    void Start()
    {
<<<<<<< HEAD
        // Starting State is Idle
        state = State.Idle;

        // It isn't attacking
        bool isAttack = false;

        // No Target Yet
        target = null;

=======
>>>>>>> PlayerMovement
        // Creating the Waypoints by looking at GameObjects with the tag "Waypoints"
        wPoints = GameObject.FindGameObjectWithTag("Waypoints").GetComponent<Waypoint>();
    }

<<<<<<< HEAD
    // Update is called once per frame
    void Update()
    {
       switch (state)
        {
            case State.Idle:
                Idle();
                break;
            case State.Attacking:
                if (!isAttack)
                {
                    isAttack = true;
                    StartCoroutine("AttackRoutine");
                    // Attacking
                }
                break;
            case State.Dying:
                Death();
                break;
        }
    }

    public void Idle()
    {
        Debug.Log("Current state is: " + state.ToString());

        // Moves the Enemy to the next waypoint depending on it's speed and position
            // Vector2 is a 2D vector from point to point
        transform.position = Vector2.MoveTowards(transform.position, wPoints.waypoints[wpIndex].position, spd * Time.deltaTime);

        // If the Enemy is within .1 of the waypoint then switch to the next waypoint (or back to the first one)
        if (Vector2.Distance(transform.position, wPoints.waypoints[wpIndex].position) < 0.1f)
        {
            // If it's not the last waypoint then continue
            if (wpIndex < wPoints.waypoints.Length - 1)
=======
    // Method to Take Damage
    public void takeDamage(int damage)
    {
        // Subtract damage from Enemies Health
        hp = hp - damage;
    }

    // Method to confirm Death and remove the Enemy Object
    public void Death()
    {

        // If the Enemies hp reaches 0.0
        if (hp == 0.0f)
        {
            // Destroy the Enemy GameObject
            Destroy(gameObject);
        }
    }

    /*
    
     // UPDATE: This can be finished after the PlayerClass has been implemented

    // Attack Method   
    public void Attack(Transform player)
    {
        // ...
    }    

    // If the Player approaches an Enemy, the Enemy will Attack
    private void OnTriggerEnter2D(Collider2D coll) 
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            float tempSpd = spd;
            spd = 0;
            Attack(target);
            spd = tempSpd;
        }
    }

    */

    // Update is called once per frame
    void Update()
    {
        // Moves the Enemy to the next waypoint depending on it's speed and position
            // Vector2 is a 2D vector from point to point
        transform.position = Vector2.MoveTowards(transform.position, wPoints.waypoints[wpIndex].position, spd * Time.deltaTime);  
        
        // If the Enemy is within .1 of the waypoint then switch to the next waypoint (or back to the first one)
        if(Vector2.Distance(transform.position, wPoints.waypoints[wpIndex].position) < 0.1f)
        {
            // If it's not the last waypoint then continue
            if(wpIndex < wPoints.waypoints.Length - 1)
>>>>>>> PlayerMovement
            {
                // Move to the next waypoint
                wpIndex++;
            }
            // Else, switch back to the last one
            // UPDATE: This will be changed to manage going from multiple different waypoints
            else
            {
                // Setting the next destination to be back to the beginning
<<<<<<< HEAD
                wpIndex = 0;
            }
        }
    }

    // Method to Take Damage
    public void takeDamage(int damage)
    {
        // Subtract damage from Enemies Health
        hp = hp - damage;

        // If HP drops below 0
        if(hp <= 0.0f)
        {
            // Change State to Dying
            state = State.Dying;
        }
    }

    // Method to Destroy Enemy when it Dies
    public void Death()
    {
        Debug.Log("Dying");
        Destroy(gameObject);
        gameObject.SetActive(false);
    }

    // Using a Routine to Attack every second
    IEnumerator AttackRoutine()
    {
        // Wait One Second
        yield return new WaitForSeconds(attSpd);
        Attack(target);
        isAttack = false;
    }

    // If a Player approaches an Enemy, the Enemy will attack
    private void OnTriggerEnter2D(Collider2D collision)
    {   
        // See if the gameobject has the Player Tag
        if (collision.gameObject.CompareTag("Player"))
        {
            target = GameObject.FindGameObjectWithTag("Player");
            state = State.Attacking;
        }
    }

    // Attack Method
    public void Attack(GameObject player)
    {
        Debug.Log("Current state is: " + state.ToString());

        // If you can target the player
        if(player != null)
        {

            // Go toward your target to attack
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, spd * Time.deltaTime);

            // If you're close enough to the player
            if (Vector2.Distance(transform.position, player.transform.position) < 3f)
            {

                TestDummy d = player.GetComponent<TestDummy>();

                // If the Player is alive
                if(d != null)
                {
                    Debug.Log("Dealing " + dmg + " damage to " + d);
                    d.takeDamage((int)dmg);
                }
                // If the Player is dead
                else
                {
                    // Back to Idle
                    state = State.Idle;
                }
            }
        }
        else
        {
            // Player is Dead, go back to Idle
            player = null;
            state = State.Idle;
        }
=======
                    // UPDATE: if this is buggy try setting it to 1
                wpIndex = 0;
            }
        }

        // Calling to check if the Enemy is dead
        Death();
>>>>>>> PlayerMovement
    }
}
