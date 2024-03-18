using UnityEngine;

public class slkdfja : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust the speed as needed
    public float moveDistance = 5f; // Adjust the distance as needed
    private float initialPosition;
    private bool moveRight = true;

    void Start()
    {
        // Store the initial position of the object
        initialPosition = transform.position.x;
    }

    void Update()
    {
        // Calculate the distance traveled
        float distanceTraveled = Mathf.Abs(transform.position.x - initialPosition);

        // Move the object left and right within the specified distance
        if (moveRight && distanceTraveled < moveDistance)
        {
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        }
        else if (!moveRight && distanceTraveled < moveDistance)
        {
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        }

        // Check if the object should change direction
        if (distanceTraveled >= moveDistance)
        {
            moveRight = !moveRight; // Change direction
            initialPosition = transform.position.x; // Update initial position
        }
    }
}
