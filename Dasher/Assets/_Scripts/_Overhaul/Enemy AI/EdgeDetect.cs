using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Detects Edges of Platforms for Enemies
public class EdgeDetect : MonoBehaviour
{
    // The Enemy
    GameObject Enemy;

    // Start is called before the first frame update
    void Start()
    {
        Enemy = gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // When the Enemy get's to the edge of a platform
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If the collision is with the edge
        if(collision.collider.tag == "Edge")
        {
            // Turn Around
            Enemy.GetComponent<Enemy>().isEdge = true;
        }   
    }
    /*
    private void OnCollisionExit2D(Collision2D collision)
    {
        // If the collision is with the edge
        if (collision.collider.tag == "Edge")
        {
            // Turn Around
            Enemy.GetComponent<Enemy>().isEdge = false;
        }
    }
    */
}
