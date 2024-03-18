using UnityEngine;

public class MoveInCircles : MonoBehaviour
{
    public float moveSpeed = 2f; // Adjust this value to control the speed of movement
    public float radius = 3f; // Adjust this value to control the radius of the circle

    private float angle = 0f;

    void Update()
    {

      
        // Calculate the next position along the circular path
        float x = Mathf.Cos(angle) * radius;
        float z = Mathf.Sin(angle) * radius;

        // Set the object's position to the calculated position
        transform.position = new Vector3(x, transform.position.y, z);
        Debug.Log("Message from circles");
        // Increment the angle to make the object move along the circle
        angle += moveSpeed * Time.deltaTime;

        // Keep the angle within the range of 0 to 360 degrees
        if (angle >= 360f)
        {
            angle -= 360f;
        }
    }
}
