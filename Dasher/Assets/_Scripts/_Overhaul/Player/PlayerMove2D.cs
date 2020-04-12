using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Overhaul Player Movement Class
public class PlayerMove2D : MonoBehaviour
{
    // Speed Attribute
    public float Spd;

    // Jump Attribute
    public float JumpForce;

    // Is the Player on the Ground?
    public bool isGrounded = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Jump Check
        Jump();

        // This determines the movement based on the typical movement keys
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * Spd;
    }

    // Jump Method
    void Jump()
    {
        // If Player presses Jump
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            // Put Force on the y-axis of the gameobject (5f)
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
        }
    }
}
