using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Basic Enemy Class
public class EnemyBasic : MonoBehaviour
{
    // Basic Stats
    public float hp;
    public float dmg;
    public float giveDmg;
    private GameObject target;

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
        }
    }

    // Attack HP Method
    public void AttackHP()
    {
        PlayerHealthManager player = target.GetComponent<PlayerHealthManager>();
        player.takeDamage(giveDmg);
    }

    void Update()
    {
        if (Enemy_behavior.attackMode)
        {
            AttackHP();
        }
        Death();
    }

    void CheckAttack()
    {
        if (target.GetComponentInChildren<Collider2D>())
        {

        }
    }

    void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.tag == "Player")
        {
            // The Target is the Player
            target = trig.gameObject;
        }
    }
}
