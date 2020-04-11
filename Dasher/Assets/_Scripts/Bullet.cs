using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 20f;
    public Rigidbody2D rb;
    //Retrieves damage from PlayerCombat class
    private int damage = PlayerCombat.attackDamage;
    private float lifeTime = 1f;
    void Start()
    {

        //Makes bullet move in direction player is facing

        if (TestDummyContorller.facingRight)
            rb.velocity = transform.right * speed;
        else
            rb.velocity = transform.right * speed * -1;
        Destroy(gameObject, lifeTime);

    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //Checks if enemy was hit
        EnemyClass enemy = hitInfo.GetComponent<EnemyClass>();
        if (enemy != null)
        {
            enemy.takeDamage(damage);
        }
        //Destroyes bullet on collision with any but player
        if (hitInfo.gameObject.tag != "Player")
            Destroy(gameObject);
    }
}

