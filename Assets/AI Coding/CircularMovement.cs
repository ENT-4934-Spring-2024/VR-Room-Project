using UnityEngine;

public class MoveInCircle : MonoBehaviour
{
    public float radius = 5f; // Radius of the circle
    public float speed = 2f; // Speed of movement
    public Material material1; // First material
    public Material material2; // Second material
    public float materialSwitchTimeMS = 500f; // Time interval to switch materials in milliseconds

    private Vector3 centerPosition;
    private float angle = 0f;
    private Renderer rend;
    private bool isMaterial1Active = true;
    private float materialSwitchTimer = 0f;

    private void Start()
    {
        centerPosition = transform.position;
        rend = GetComponent<Renderer>();
        rend.material = material1; // Set initial material
    }

    private void Update()
    {
        // Calculate the new position based on angle and radius
        float x = centerPosition.x + Mathf.Cos(angle) * radius;
        float z = centerPosition.z + Mathf.Sin(angle) * radius;

        // Update the object's position
        transform.position = new Vector3(x, transform.position.y, z);

        // Calculate the rotation to look forward
        Vector3 direction = new Vector3(-Mathf.Sin(angle), 0f, Mathf.Cos(angle));
        Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);

        // Apply rotation
        transform.rotation = rotation;

        // Increment angle based on speed
        angle += speed * Time.deltaTime;

        // Keep angle within 0 to 2*pi range
        if (angle > Mathf.PI * 2)
        {
            angle -= Mathf.PI * 2;
        }

        // Timer for material switching in milliseconds
        materialSwitchTimer += Time.deltaTime * 1000f;
        if (materialSwitchTimer >= materialSwitchTimeMS)
        {
            // Switch materials
            if (isMaterial1Active)
                rend.material = material2;
            else
                rend.material = material1;

            // Reset timer and toggle material flag
            materialSwitchTimer = 0f;
            isMaterial1Active = !isMaterial1Active;
        }
    }
}
