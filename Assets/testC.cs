using UnityEngine;

public class testC : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed at which the object moves
    public float leftLimit = -5f; // Left limit of movement
    public float rightLimit = 5f; // Right limit of movement

    private bool movingRight = true; // Indicates if the object is currently moving right

    void Update()
    {
        if (movingRight)
        {
            // Move the object to the right
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);

            // Check if the object has reached the right limit
            if (transform.position.x >= rightLimit)
            {
                // Change direction to left
                movingRight = false;
            }
        }
        else
        {
            // Move the object to the left
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

            // Check if the object has reached the left limit
            if (transform.position.x <= leftLimit)
            {
                // Change direction to right
                movingRight = true;
            }
        }
    }
}
