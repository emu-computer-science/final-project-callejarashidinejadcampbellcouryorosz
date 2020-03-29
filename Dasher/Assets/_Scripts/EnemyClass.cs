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

    }    


    */


}
