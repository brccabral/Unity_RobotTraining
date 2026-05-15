using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector3 movementDirection;
    [SerializeField] private float moveSpeed = 5f;
    public Vector3 lookRotationDirection;
    [SerializeField] private float lookSensitivity = 100f;
    [SerializeField] private float jumpForce = 10f;

    private CharacterController characterController;
    private Camera firstPersonCamera;
    private CustomPhysicsModule customPhysicsModule;
    private ShootingModule shootingModule;
    private PlayerInteractorModule interactorModule;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        firstPersonCamera = GetComponentInChildren<Camera>();
        characterController = GetComponent<CharacterController>();
        customPhysicsModule = GetComponent<CustomPhysicsModule>();
        shootingModule = GetComponent<ShootingModule>();
        interactorModule = GetComponent<PlayerInteractorModule>();
    }

    // Update is called once per frame
    private void Update()
    {
        JumpInput();
        MoveInput();
        LookInput();
        ShootInput();
        InteractInput();
    }

    private void MoveInput()
    {
        movementDirection.x = Input.GetAxisRaw("Horizontal");
        movementDirection.z = Input.GetAxisRaw("Vertical");
        movementDirection = movementDirection.normalized;

        var forward = characterController.transform.forward * movementDirection.z;
        var right = characterController.transform.right * movementDirection.x;
        var gravity = customPhysicsModule.upDownForce;

        characterController.Move(((forward + right) * moveSpeed + gravity) * Time.deltaTime);
    }

    private void LookInput()
    {
        lookRotationDirection.y += Input.GetAxisRaw("Mouse X") * (Time.deltaTime * lookSensitivity);
        lookRotationDirection.x -= Input.GetAxisRaw("Mouse Y") * (Time.deltaTime * lookSensitivity);
        lookRotationDirection.x = Mathf.Clamp(lookRotationDirection.x, -80, 80);

        firstPersonCamera.transform.localEulerAngles = new Vector3(lookRotationDirection.x, 0, 0);
        characterController.transform.eulerAngles = new Vector3(0, lookRotationDirection.y, 0);
    }

    private void JumpInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            customPhysicsModule.AddForceUp(jumpForce);
        }
    }

    private void ShootInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            shootingModule.Shoot();
        }
    }

    private void InteractInput()
    {
        if (Input.GetMouseButtonDown(1))
        {
            interactorModule.InteractWith();
        }
        else if (Input.GetMouseButtonUp(1))
        {
            interactorModule.StopInteractWith();
        }
    }
}
