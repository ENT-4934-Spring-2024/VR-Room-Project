
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust this value to control the speed of movement
    public float moveDistance = 5f; // Adjust this value to control the distance of movement

    private Vector3 startPos;
    private Vector3 leftTargetPos;
    private Vector3 rightTargetPos;
    private bool moveRight = true;

    void Start()
    {
        // Store the initial position of the object
        startPos = transform.position;

        // Calculate the target positions for left and right movement
        leftTargetPos = startPos + Vector3.left * moveDistance;
        rightTargetPos = startPos + Vector3.right * moveDistance;
    }

    void Update()
    {
        //  Debug.Log("Script started.");

       
        // Calculate the direction and distance to move
        Vector3 direction = moveRight ? Vector3.right : Vector3.left;
        Vector3 targetPos = moveRight ? rightTargetPos : leftTargetPos;
        
        // Move the object
        transform.Translate(direction * moveSpeed * Time.deltaTime);
        Debug.Log("Script started from movement");
        // If the object reaches the target position, switch direction
        if (Vector3.Distance(transform.position, targetPos) < 0.01f)
        {
            moveRight = !moveRight;
        }
    }
}
