using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Overhaul - Enemy Class
public class Enemy : MonoBehaviour
{
    // Different States of the Enemy
    public enum State
    {
        // Idle Mode
        Idle,
        // Attack Mode
        Attacking,
        // Dying Mode
        Dying
    }

    // Basic Attributes
    public float hp;
    public float dmg;
    public float spd;
    public float attSpd;

    // Moving Direction
    private bool movingRight = true;

    // Detections For Patrols
    public bool isEdge = false;

    // The Player Target
    GameObject target;

    // The State of the Enemy
    public State state;

    // Is the Enemy Attacking?
    bool isAttack = false;

    // Start Method
    void Start()
    {
        // Starting State is Idle
        state = State.Idle;

        // No Target Yet
        target = null;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.Idle:
                Idle();
                break;
            case State.Attacking:
                if (!isAttack)
                {
                    isAttack = true;
                    StartCoroutine("AttackRoutine");
                    // Attacking
                }
                break;
            case State.Dying:
                Death();
                break;
        }
    }

    public void Idle()
    {
        transform.Translate(Vector2.right * spd * Time.deltaTime);

        if(isEdge == false)
        {
            if(movingRight == true)
            {
                // Move Right
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
        }
        else
        {
            // Move Left
            transform.eulerAngles = new Vector3(0, 0, 0);
            movingRight = true;
        }
    }

    // Method to Take Damage
    public void takeDamage(int damage)
    {
        // Subtract damage from Enemies Health
        hp = hp - damage;

        // If HP drops below 0
        if (hp <= 0.0f)
        {
            // Change State to Dying
            state = State.Dying;
        }
    }

    // Method to Destroy Enemy when it Dies
    public void Death()
    {
        Debug.Log("Dying");
        Destroy(gameObject);
        gameObject.SetActive(false);
    }

    // Using a Routine to Attack every second
    IEnumerator AttackRoutine()
    {
        // Wait One Second
        yield return new WaitForSeconds(attSpd);
        Attack(target);
        isAttack = false;
    }

    // If a Player approaches an Enemy, the Enemy will attack
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // See if the gameobject has the Player Tag
        if (collision.gameObject.CompareTag("Player"))
        {
            target = GameObject.FindGameObjectWithTag("Player");
            state = State.Attacking;
        }
    }

    // Attack Method
    public void Attack(GameObject player)
    {
        Debug.Log("Current state is: " + state.ToString());

        // If you can target the player
        if (player != null)
        {

            // Go toward your target to attack
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, spd * Time.deltaTime);

            // If you're close enough to the player
            if (Vector2.Distance(transform.position, player.transform.position) < 3f)
            {

                Player p = player.GetComponent<Player>();

                // If the Player is alive
                if (p != null)
                {
                    Debug.Log("Dealing " + dmg + " damage to " + p);
                    p.takeDamage((int)dmg);
                }
                // If the Player is dead
                else
                {
                    // Back to Idle
                    state = State.Idle;
                }
            }
        }
        else
        {
            // Player is Dead, go back to Idle
            player = null;
            state = State.Idle;
        }
    }
}
