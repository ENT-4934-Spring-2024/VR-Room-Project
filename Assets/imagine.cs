using UnityEngine;

public class imagine : MonoBehaviour
{
    public float radius = 5f; // Radius of the circle
    public float speed = 2f; // Speed of movement
    public float rotationSpeed = 30f; // Speed of rotation
    public Color[] colors; // Array of colors to cycle through
    public Material[] materials; // Array of materials corresponding to colors
    public GameObject[] shapes; // Array of shapes to cycle through

    public Mesh[] meshes;

    private float angle = 0f;
    private int colorIndex = 0;
    private int shapeIndex = 0;

    private void Start()
    {
        // Set initial color and shape
        SetColorAndShape();
    }

    private void Update()
    {
        // Move in a circle
        Vector3 newPosition = new Vector3(Mathf.Cos(angle) * radius, transform.position.y, Mathf.Sin(angle) * radius);
        transform.position = newPosition;

        // Rotate around the center of the circle
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

        // Increment angle
        angle += speed * Time.deltaTime;

        // Check if a full rotation is completed
        if (angle >= 360f)
        {
            // Change color and shape
            colorIndex = (colorIndex + 1) % colors.Length;
            shapeIndex = (shapeIndex + 1) % shapes.Length;
            SetColorAndShape();

            angle = 0f; // Reset angle
        }
    }

    // Set the color and shape of the object
    private void SetColorAndShape()
    {
        // Set color
        GetComponent<Renderer>().material = materials[colorIndex];

        // Set shape
        for (int i = 0; i < shapes.Length; i++)
        {
            GetComponent<MeshFilter>().mesh = meshes[i];
        }
    }
}
