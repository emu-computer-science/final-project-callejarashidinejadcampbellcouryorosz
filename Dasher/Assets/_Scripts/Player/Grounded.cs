using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{
    // The Player
    GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = gameObject.transform.parent.gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // When the Player is on the ground
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If the collision is with the ground
        if(collision.collider.tag == "Ground")
        {
            // On the Ground
            Player.GetComponent<PlayerController>().isGrounded = true;
        } 
    }

    // When the Player is off the ground
    private void OnCollisionExit2D(Collision2D collision)
    {
        // If the collision is with the ground
        if (collision.collider.tag == "Ground")
        {
            // Off the Ground
            Player.GetComponent<PlayerController>().isGrounded = false;
        }
    }
}
