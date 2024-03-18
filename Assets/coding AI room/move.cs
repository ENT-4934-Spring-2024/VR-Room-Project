using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 5f; // Adjust the speed of movement
    public float distance = 5f; // Adjust the distance to move

    private Vector3 startPosition;
    private bool movingForward = true;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (movingForward)
        {
            MoveObject(transform.position + Vector3.right * speed * Time.deltaTime);

            if (Vector3.Distance(startPosition, transform.position) >= distance)
            {
                movingForward = false;
            }
        }
        else
        {
            MoveObject(transform.position - Vector3.right * speed * Time.deltaTime);

            if (Vector3.Distance(startPosition, transform.position) <= 0.01f)
            {
                movingForward = true;
            }
        }
    }

    void MoveObject(Vector3 targetPosition)
    {
        transform.position = targetPosition;
    }
}
