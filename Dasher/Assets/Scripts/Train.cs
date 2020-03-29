using UnityEngine;
public class Train : MonoBehaviour
{
    public float speed = -1;
    private void Update()
    {
        // We add +1 to the x axis every frame.
        // Time.deltaTime is the time it took to complete the last frame
        // The result of this is that the object moves one unit on the x axis every second
        transform.position += new Vector3(-1*(speed * Time.deltaTime), 0, 0);
    }
}