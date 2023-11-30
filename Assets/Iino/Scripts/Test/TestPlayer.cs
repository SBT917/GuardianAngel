using UnityEngine;

public class SimpleFPSController : MonoBehaviour
{
    public float speed = 5.0f;
    public float mouseSensitivity = 100.0f;
    public float jumpHeight = 1.0f;
    public float ascendSpeed = 5.0f;

    private CharacterController controller;
    private float yRotation = 0.0f;
    private float yVelocity = 0.0f;
    private bool isGrounded;
    private bool isFreeMode = false;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GetComponent<Rigidbody>().useGravity = !GetComponent<Rigidbody>().useGravity;
            isFreeMode = !isFreeMode;

            if (isFreeMode)
            {
                yVelocity = 0.0f;
            }
        }

        if (!isFreeMode)
        {
            // 通常の移動モード
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            yRotation -= mouseY;
            yRotation = Mathf.Clamp(yRotation, -90f, 90f);

            transform.Rotate(Vector3.up * mouseX);
            Camera.main.transform.localRotation = Quaternion.Euler(yRotation, 0f, 0f);

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;
            controller.Move(move * speed * Time.deltaTime);

            if (controller.isGrounded && yVelocity < 0)
            {
                yVelocity = -2f;
            }

            if (Input.GetButtonDown("Jump") && controller.isGrounded)
            {
                yVelocity = Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y);
            }

            yVelocity += Physics.gravity.y * Time.deltaTime;
            controller.Move(new Vector3(0, yVelocity, 0) * Time.deltaTime);
        }
        else
        {
            // 自由な飛び回りモード
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            yRotation -= mouseY;
            yRotation = Mathf.Clamp(yRotation, -90f, 90f);

            transform.Rotate(Vector3.up * mouseX);
            Camera.main.transform.localRotation = Quaternion.Euler(yRotation, 0f, 0f);

            float verticalMovement = Input.GetAxis("Vertical");
            float horizontalMovement = Input.GetAxis("Horizontal");

            Vector3 freeModeMove = (transform.forward * verticalMovement + transform.right * horizontalMovement) * speed * Time.deltaTime;
            controller.Move(freeModeMove);

            if (Input.GetKey(KeyCode.Space))
            {
                Vector3 ascend = Vector3.up * ascendSpeed * Time.deltaTime;
                controller.Move(ascend);
            }
        }
    }
}
