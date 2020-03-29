using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is the Basic Enemy Class
// We're looking to apply this to multiple different types of enemies
public class EnemyClass : MonoBehaviour
{

    // Basic Attributes
    public float hp;
    public float dmg;
    public float spd;

    // Waypoint Array Object
    // This is directing the path for our Enemy AI
    Waypoint wPoints;

    // Waypoint Index
    int wpIndex;

    // The Player Target
    // This is the direction of the player
    public Transform target;

    // Start Method
    void Start()
    {
        // Creating the Waypoints by looking at GameObjects with the tag "Waypoints"
        wPoints = GameObject.FindGameObjectWithTag("Waypoints").GetComponent<Waypoint>();
    }

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
            {
                // Move to the next waypoint
                wpIndex++;
            }
            // Else, switch back to the last one
            // UPDATE: This will be changed to manage going from multiple different waypoints
            else
            {
                // Setting the next destination to be back to the beginning
                    // UPDATE: if this is buggy try setting it to 1
                wpIndex = 0;
            }
        }

        // Calling to check if the Enemy is dead
        Death();
    }
}
