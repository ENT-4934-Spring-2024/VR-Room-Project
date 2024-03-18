using UnityEngine;

public class PlaneController : MonoBehaviour
{
    public float speed = 10f;
    public float rotationSpeed = 100f;

    void Update()
    {
        // Get input for movement along the forward/backward axis (Up/Down arrow keys or W/S keys)
        float moveVertical = Input.GetAxis("Vertical");

        // Get input for movement along the right/left axis (Right/Left arrow keys or A/D keys)
        float moveHorizontal = Input.GetAxis("Horizontal");

        // Get input for movement along the up/down axis (PageUp/PageDown keys or Q/E keys)
        float moveUp = Input.GetAxis("MoveUp");
        float moveDown = Input.GetAxis("MoveDown");

        // Calculate translation based on input and speed
        Vector3 translation = (transform.forward * moveVertical + transform.right * moveHorizontal + transform.up * (moveUp - moveDown)) * speed * Time.deltaTime;

        // Apply translation
        transform.Translate(translation);

        // Get input for rotation around the yaw axis (A/D keys or Left/Right arrow keys)
        float rotateYaw = Input.GetAxis("Yaw");

        // Get input for rotation around the pitch axis (Q/E keys or PageUp/PageDown keys)
        float rotatePitch = Input.GetAxis("Pitch");

        // Get input for rotation around the roll axis (Insert/Delete keys or LeftCtrl/LeftShift with Left/Right arrow keys)
        float rotateRoll = Input.GetAxis("Roll");

        // Calculate rotation based on input and rotation speed
        float rotationYaw = rotateYaw * rotationSpeed * Time.deltaTime;
        float rotationPitch = rotatePitch * rotationSpeed * Time.deltaTime;
        float rotationRoll = rotateRoll * rotationSpeed * Time.deltaTime;

        // Apply rotation around the y-axis for yaw
        transform.Rotate(0f, rotationYaw, 0f);

        // Apply rotation around the x-axis for pitch
        transform.Rotate(rotationPitch, 0f, 0f);

        // Apply rotation around the z-axis for roll
        transform.Rotate(0f, 0f, -rotationRoll);
    }
}
