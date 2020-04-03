using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    private int damage = PlayerCombat.attackDamage;
    // Start is called before the first frame update
    void Start()
    {
        //Till we get player moving -1 stays. Will change with player controller
        rb.velocity = transform.right * speed * -1;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        EnemyClass enemy = hitInfo.GetComponent<EnemyClass>();
        if (enemy != null)
        {
            Debug.Log("Attack damage " + damage);
            enemy.takeDamage(damage);
        }
        Destroy(gameObject);
    }
}

