using UnityEngine;
public class Train : MonoBehaviour
{
    public float speed = -1;
    public float startX = -14;
    public float endX = -55;
    private void Update()
    {
        // We add +1 to the x axis every frame.
        // Time.deltaTime is the time it took to complete the last frame
        // The result of this is that the object moves one unit on the x axis every second
        transform.position += new Vector3(-1 * (speed * Time.deltaTime), 0, 0);

        //Check if the difference along the x axis between the main Camera and the position of the object this is attached to is greater than groundHorizontalLength.
        if (transform.position.x <startX)
        {
            //If true, this means this object is no longer visible and we can safely move it forward to be re-used.
            RepositionBackground();
        }
    }

        //Moves the object this script is attached to right in order to create our looping background effect.
        private void RepositionBackground()
        {
            //This is how far to the right we will move our background object, in this case, twice its length. This will position it directly to the right of the currently visible background object.
            Vector2 groundOffSet = new Vector2(endX, 2);

            //Move this object from it's position offscreen, behind the player, to the new position off-camera in front of the player.
            transform.position = groundOffSet;
        }
    }
