using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Basic Enemy Class
public class EnemyBasic : MonoBehaviour
{
    // Basic Stats
    public float hp;
    public float dmg;

    public GameObject ammoPrefab;

    // Take Damage Method
    public void takeDamage(int damage)
    {
        // HP is equal to previous health minus damage
        hp = hp - damage;
    }

    // Method to detect if it's dead
    public void Death()
    {
        // If the enemy's health reaches 0.0
        if (hp == 0.0f)
        {
            // Destroy the Enemy
            Destroy(gameObject);
            if (ammoPrefab != null)
            {
                //Gets enemy position
                Vector2 enemyPos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
                //Drops ammoPrefab on enemy Death
                Instantiate(ammoPrefab, enemyPos, Quaternion.identity);
            }
        }
    }

    // Update Method
    void Update()
    {
        // Check if Enemy is dead
        Death();
    }
}
