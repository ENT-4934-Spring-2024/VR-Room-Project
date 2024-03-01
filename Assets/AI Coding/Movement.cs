using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of movement
    public float moveDistance = 5f; // Distance to move in each direction

    private bool movingRight = true;
    private Vector3 originalPosition;
    private float moveAmount;

    private void Start()
    {
        originalPosition = transform.position;
        moveAmount = 0f;
    }

    private void Update()
    {
        // Calculate movement amount based on current direction
        float movement = moveSpeed * Time.deltaTime;
        moveAmount += movement;

        // Check if we need to change direction
        if (moveAmount >= moveDistance)
        {
            // Change direction
            movingRight = !movingRight;
            moveAmount = 0f;
        }

        // Move the object
        if (movingRight)
        {
            transform.Translate(Vector3.right * movement);
        }
        else
        {
            transform.Translate(Vector3.left * movement);
        }
    }
}
