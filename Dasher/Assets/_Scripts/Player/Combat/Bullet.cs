using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    //Retrieves damage from PlayerCombat class
    private int damage = OverhaulCombat.attackDamage;
    private float lifeTime = 3f;

    void Start()
    {
        //Makes bullet move in direction player is facing

        if (PlayerController.isFacingRight)
            rb.velocity = transform.right * speed;
        else
            rb.velocity = transform.right * speed;
        Destroy(gameObject, lifeTime);

    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //Makes editor happy
        EnemyBasic enemy = null;

        //Destroyes bullet on collision with anything but player, potions, or enemy detection
        if (!hitInfo.CompareTag("Player") && !hitInfo.CompareTag("Potions") && !hitInfo.CompareTag("Function"))
        {
            Debug.Log(hitInfo.CompareTag("Function"));
            Destroy(gameObject);
        }

        if (hitInfo.CompareTag("Enemy"))
        {
            //hitInfo is actually hitting collider of enemy not enemy itself
            //So we need to get parent of collider where the EnemyBasic script resides
            if (hitInfo.transform.parent != null)
                enemy = hitInfo.transform.parent.GetComponent<EnemyBasic>();
            else
                enemy = hitInfo.GetComponent<EnemyBasic>();
            if (enemy != null)
                enemy.takeDamage(damage);
        }
    }
}

