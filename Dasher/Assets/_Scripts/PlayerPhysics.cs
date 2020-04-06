using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class PlayerPhysics : MonoBehaviour
{
    public LayerMask collisionMask;
    private BoxCollider2D collider;
    Vector3 s;
    Vector3 c;

    private float skin = .005f;

    public bool grounded;

    Ray ray;
    RaycastHit hit;


    private void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        s = collider.size;
        c = collider.offset;
    }

    public void Move(Vector2 moveAmount)
    {

        float deltaY = moveAmount.y;
        float deltaX = moveAmount.x;
        Vector2 p = transform.position;

        grounded = false;

        for (int i = 0; i < 3; i++)
        {
            float dir = Mathf.Sign(deltaY);
            float x = (p.x + c.x - s.x / 2) + s.x / 2 * i; //left, center, and rightmost point of collider
            float y = p.y + c.y + s.y / 2 * dir; //bottom of collider

            ray = new Ray(new Vector2(x, y), new Vector2(0, dir));
            Debug.DrawRay(ray.origin, ray.direction);

            if (Physics.Raycast(ray, out hit, Mathf.Abs(deltaY), collisionMask))
            {
                //Get distance between player and ground
                float dst = Vector3.Distance(ray.origin, hit.point);

                //Stop player's downward movement after coming within skin width of a collider
                if (dst > skin)
                {
                    deltaY = -dst + skin;
                }
                else
                {
                    deltaY = 0;
                }

                grounded = true;
                break;
            }
        }
        Vector2 finalTransform = new Vector2(deltaX, deltaY);
        transform.Translate(finalTransform);
    }
}
