using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    //Retrieves damage from PlayerCombat class
    private int damage = PlayerCombat.attackDamage;
    void Start()
    {
        //Till we get player moving -1 stays. Will change with player controller
        //Makes bullet move
        rb.velocity = transform.right * speed * -1;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //Checks if enemy was hit
        EnemyClass enemy = hitInfo.GetComponent<EnemyClass>();
        if (enemy != null)
        {
            enemy.takeDamage(damage);
        }
        //Destroyes bullet on collision
        Destroy(gameObject);
    }
}

