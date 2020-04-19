using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitCheck : MonoBehaviour
{
    // This is the Player Health Manager
    PlayerHealthManager player;

    // This is the Enemy Parent
    EnemyBasic enemy;

    // If the Player Enters the Hit Box
    public void OnTriggerEnter2D(Collider2D collision)
    {
        // If the Collision is caused by the Player
        if (collision.CompareTag("Player"))
        {
            // Get the Player
            Debug.Log("Enemy Hit!");
            player = collision.transform.parent.GetComponent<PlayerHealthManager>();

            // Storing the Enemy
            enemy = transform.parent.GetComponent<EnemyBasic>();

            // Enemies Damage
            float damg = enemy.dmg;

            // Player Takes Damage 
            player.takeDamage(damg);
        }
    }
}
