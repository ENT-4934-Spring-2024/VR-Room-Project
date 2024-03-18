using UnityEngine;

public class mouvement : MonoBehaviour
{
    public float radius = 5f; // Radius of the circle
    public float speed = 2f; // Speed of movement
    public float rotationSpeed = 30f; // Speed of rotation
    public Color[] colors; // Array of colors to cycle through
    public GameObject[] shapes; // Array of shapes to cycle through
    public float changeInterval = 1f; // Interval between color and shape changes

    private float angle = 0f;
    private int colorIndex = 0;
    private int shapeIndex = 0;
    private float changeTimer = 0f;

    private void Start()
    {
        // Set initial color and shape
        GetComponent<Renderer>().material.color = colors[colorIndex];
        SetShape(shapes[shapeIndex]);
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

        // Change color and shape at specified intervals
        changeTimer += Time.deltaTime;
        if (changeTimer >= changeInterval)
        {
            // Change color
            colorIndex = (colorIndex + 1) % colors.Length;
            GetComponent<Renderer>().material.color = colors[colorIndex];

            // Change shape
            shapeIndex = (shapeIndex + 1) % shapes.Length;
            SetShape(shapes[shapeIndex]);

            changeTimer = 0f;
        }
    }

    // Set the shape of the object
    private void SetShape(GameObject shape)
    {
        for (int i = 0; i < shapes.Length; i++)
        {
            shapes[i].SetActive(false);
        }
        shape.SetActive(true);
    }
}
