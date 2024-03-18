using UnityEngine;

public class MoveLeftAndRight : MonoBehaviour
{
    public float moveSpeed = 5f;  // Adjust the speed as needed
    public float timeToMove = 2f; // Adjust the time for each direction

    private float timer;
    private bool moveRight = true;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer < timeToMove)
        {
            if (moveRight)
                transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            else
                transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
        else
        {
            timer = 0f;
            moveRight = !moveRight;
        }
    }
}
