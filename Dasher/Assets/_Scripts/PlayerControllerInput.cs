using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerPhysics))]

public class PlayerControllerInput : MonoBehaviour
{
    //Player Handling
    public float gravity = 20;
    public float speed = 8;
    public float acceleration = 30;
    public float jumpHeight = 12;

    private float currentSpeed;
    private float targetSpeed;
    private Vector2 amountToMove;

    private PlayerPhysics playerPhysics;
    // Start is called before the first frame update
    void Start()
    {
        playerPhysics = GetComponent<PlayerPhysics>();
    }

    // Update is called once per frame
    void Update()
    {
        targetSpeed = Input.GetAxisRaw("Horizontal") * speed;
        currentSpeed = IncrementTowards(currentSpeed, targetSpeed, acceleration);

        if (playerPhysics.grounded) {
            amountToMove.y = 0;
            
            //Jump
            if (Input.GetButtonDown("Jump")) {
                amountToMove.y = jumpHeight;
            }
        }

        amountToMove.x = currentSpeed;
        amountToMove.y -= gravity * Time.deltaTime;
        playerPhysics.Move(amountToMove * Time.deltaTime);
    }

    //increment n toward target by speed
    private float IncrementTowards(float n, float target, float speed) {
        if (n == target) {
            return n;
        }
        else
        {
            float dir = Mathf.Sign(target - n); //increase or decrease to get closer to target speed
            n += speed * Time.deltaTime * dir;
            return (dir == Mathf.Sign(target - n)) ? n : target;
        }
    }
    
}
