using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public float pitchSpeed = 5f;
    public float rollSpeed = 5f;
    public float forwardSpeed = 10f;
    public float minSpeedToStayAirborne = 5f;
    public float gravity = 9.81f;

    private Rigidbody rb;
    private PlayerControls controls;

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        controls = new PlayerControls();

        // Add a check to ensure the actions exist before assigning the callbacks

            controls.Movement.Pitch.performed += ctx => OnPitchInput(ctx.ReadValue<float>());
            controls.Movement.Roll.performed += ctx => OnRollInput(ctx.ReadValue<float>());
    }

    private void OnPitchInput(float pitchInput)
    {
        // Apply pitch rotation to the plane
        Vector3 rotation = new Vector3(pitchInput * pitchSpeed, 0f, 0f);
        rb.AddRelativeTorque(rotation * Time.deltaTime);
    }

    private void OnRollInput(float rollInput)
    {
        // Apply roll rotation to the plane
        Vector3 rotation = new Vector3(0f, 0f, -rollInput * rollSpeed);
        rb.AddRelativeTorque(rotation * Time.deltaTime);
    }

    private void Update()
    {
        // Calculate forward direction based on rotation
        Vector3 forwardDirection = transform.forward;

        // Apply forward movement using Rigidbody.velocity
        rb.velocity = forwardDirection * forwardSpeed;

        // Apply gravity
        rb.AddForce(Vector3.down * gravity * rb.mass);

        // Check if the speed is too low to stay airborne
        if (rb.velocity.magnitude < minSpeedToStayAirborne)
        {
            // Add additional downward force to simulate falling
            rb.AddForce(Vector3.down * gravity * rb.mass * 2f);
        }
    }
}
