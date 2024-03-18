using UnityEngine;

public class VerticalSphere : MonoBehaviour
{
    public Transform centerPoint; // The center point of the circle
    public float rotateSpeed = 15f; // Adjust this value to control the speed of rotation
    public float radius = 10f; // Adjust this value to control the radius of the circle

    private float angle = 0f;

    void Update()
    {
        // Calculate the position on the circle using trigonometry
        float x = centerPoint.position.x + Mathf.Cos(angle) * radius;
        float z = centerPoint.position.z + Mathf.Sin(angle) * radius;

        // Set the object's position to the calculated position
        transform.position = new Vector3(x, transform.position.y, z);

        // Increment the angle to make the object move along the circle
        angle += rotateSpeed * Time.deltaTime;

        // Keep the angle within the range of 0 to 360 degrees
        if (angle >= 360f)
        {
            angle -= 360f;
        }
    }
}
