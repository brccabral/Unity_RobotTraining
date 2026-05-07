using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector3 movementDirection;
    [SerializeField] private float moveSpeed = 5f;
    public Vector3 lookRotationDirection;
    [SerializeField] private float lookSensitivity = 100f;

    private CharacterController characterController;
    private Camera firstPersonCamera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        firstPersonCamera = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveInput();
        LookInput();
    }

    private void MoveInput()
    {
        movementDirection.x = Input.GetAxisRaw("Horizontal");
        movementDirection.z = Input.GetAxisRaw("Vertical");
        movementDirection = movementDirection.normalized;

        var forward = characterController.transform.forward * movementDirection.z;
        var right = characterController.transform.right * movementDirection.x;
        var gravity = Vector3.up;

        characterController.Move((forward + right) * (Time.deltaTime * moveSpeed));
    }

    private void LookInput()
    {
        lookRotationDirection.y += Input.GetAxisRaw("Mouse X") * (Time.deltaTime * lookSensitivity);
        lookRotationDirection.x -= Input.GetAxisRaw("Mouse Y") * (Time.deltaTime * lookSensitivity);
        lookRotationDirection.x = Mathf.Clamp(lookRotationDirection.x, -80, 80);

        firstPersonCamera.transform.localEulerAngles = new Vector3(lookRotationDirection.x, 0, 0);
        characterController.transform.eulerAngles = new Vector3(0, lookRotationDirection.y, 0);
    }
}
