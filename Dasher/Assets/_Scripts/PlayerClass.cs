using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is the Player Class with Stats
public class PlayerClass : MonoBehaviour
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

    public void takeDamage(int damage)
    {
        hp = hp - damage;

        if (hp <= 0.0f)
        {
            Death();
        }
    }

    public void Death()
    {
        Debug.Log("Player has Died");
        Destroy(gameObject);
        gameObject.SetActive(false);
    }
}
