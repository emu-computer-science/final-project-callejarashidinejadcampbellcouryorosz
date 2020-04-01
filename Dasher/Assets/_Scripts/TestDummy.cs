using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is a TestDummy class to test things on him in game
public class TestDummy : MonoBehaviour
{
    // Different States of the Test Dummy
    public enum State
    {
        // Stationary
        Stationary,
        // Dying
        Dying
    }

    // Basic Stats
    public float hp;

    // The State of the Test Dummy
    public State state;

    // Start is called before the first frame update
    void Start()
    {
        // Starting State is Stationary
        state = State.Stationary;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.Stationary:
                break;
            case State.Dying:
                Death();
                break;
        }
    }

    public void Death()
    {
        Debug.Log("Dummy Destroyed");
        Destroy(gameObject);
        gameObject.SetActive(false);
    }

    // Method to take damage
    public void takeDamage(int damage)
    {
        // Health is equal to previous health minus damage
        hp = hp - damage;

        // If health is below 0
        if (hp <= 0.0f)
        {
            // Change state to Dying
            state = State.Dying;
        }
    }
}
