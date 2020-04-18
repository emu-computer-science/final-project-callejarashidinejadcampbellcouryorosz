using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    private float hp;
    public float maxhp;
    // Start is called before the first frame update
    void Start()
    {
        hp = maxhp;
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0.0f)
        {
            Death();
        }
    }

    public void takeDamage(float damage)
    {
        // Health is equal to previous health minus damage
        hp = hp - damage;

        // If health is below 0
        if (hp <= 0.0f)
        {
            // Change state to Dying
            Death();
        }
    }

    public void Death()
    {
        Debug.Log("Dummy Destroyed");
        Destroy(gameObject);
        gameObject.SetActive(false);
    }
}
