using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Player Health Manager Class
public class PlayerHealthManager : MonoBehaviour
{
    // Hp for Player
    public float hp;
    public float startHp;

    void Start()
    {
        hp = startHp;
    }

    // Update is called once per frame
    void Update()
    {
        // Call Check Death
        checkDeath();
    }

    // Take Damage Method
    public void takeDamage(float damage)
    {
        // Health is equal to previous health minus damage
        hp = hp - damage;
        Debug.Log("Player HP: " + hp);
    }

    // Is the Player Alive?
    public void checkDeath()
    {
        // If hp is below 0
        if (hp <= 0.0f)
        {
            // Destroy Player
            Death();
        }
    }

    // Destroy Player
    public void Death()
    {
        Debug.Log("Player has Died");
        Destroy(gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //gameObject.SetActive(false);
    }
}
