using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Overhaul - Player Class
public class Player : MonoBehaviour
{
    // Basic Attributes
    public float hp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    // Method to take damage as the player
    public void takeDamage(int damage)
    {
        // Health - damage is the new Health
        hp = hp - damage;

        // If the player's HP drops to or below 0
        if (hp <= 0.0f)
        {
            // The Player Died
            Death();
        }
    }

    // Method to destroy the player when the player has died
    public void Death()
    {
        Debug.Log("Player has Died");
        Destroy(gameObject);
        gameObject.SetActive(false);
    }
}
