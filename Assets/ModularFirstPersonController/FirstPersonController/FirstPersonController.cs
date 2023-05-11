using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    public Camera playerCamera;

    private float inputX;
    private float inputZ;
    private Vector3 moveDirection;
    private CharacterController controller;
    private Vector2 touchStartPosition;
    public float mouseSensitivity = 12f;
    private float yaw = 0f;
    private float pitch = 0f;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        yaw = transform.eulerAngles.y;
        pitch = playerCamera.transform.localEulerAngles.x;

    }

    private void Update()
    {
        HandleMobileInput();
    }

    private void FixedUpdate()
    {
        HandleMobileMovement();
    }

    private void HandleMobileInput()
    {
        float movementThreshold = 20f; // Define a threshold value for the movement

        foreach (Touch touch in Input.touches)
        {
            if (touch.position.x < Screen.width / 2) // Left side of the screen for movement
            {
                if (touch.phase == TouchPhase.Began)
                {
                    touchStartPosition = touch.position;
                }
                else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
                {
                    float touchDistance = Vector2.Distance(touchStartPosition, touch.position);

                    if (touchDistance > movementThreshold)
                    {
                        inputX = (touch.position.x - Screen.width / 4) / (Screen.width / 4);
                        inputZ = (touch.position.y - Screen.height / 4) / (Screen.width / 4);
                    }
                }
                else if (touch.phase == TouchPhase.Ended)
                {
                    inputX = 0;
                    inputZ = 0;
                }
            }
            else if (touch.position.x > Screen.width / 2) // Right side of the screen for camera control
            {
                if (touch.phase == TouchPhase.Moved)
                {
                    yaw += touch.deltaPosition.x * mouseSensitivity * Time.deltaTime;
                    pitch -= touch.deltaPosition.y * mouseSensitivity * Time.deltaTime;

                    pitch = Mathf.Clamp(pitch, -90f, 90f);

                    transform.localEulerAngles = new Vector3(0, yaw, 0);
                    playerCamera.transform.localEulerAngles = new Vector3(pitch, 0, 0);
                }
            }
        }

        // Update the movement direction
        moveDirection = transform.TransformDirection(new Vector3(inputX, 0, inputZ));
        moveDirection.y = 0;
        moveDirection.Normalize();
    }

    private void HandleMobileMovement()
    {
        float moveSpeed = 26f; // Define the desired move speed
        Vector3 move = moveDirection * moveSpeed * Time.fixedDeltaTime;
        controller.Move(move);
    }
}
