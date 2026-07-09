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

    private bool isLookingAround;
    private float lookAroundTimer;

    private bool isWalking;
    private float walkTimer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        firstPersonCamera = GetComponentInChildren<Camera>();
        characterController = GetComponentInChildren<CharacterController>();
        customPhysicsModule = GetComponentInChildren<CustomPhysicsModule>();
        shootingModule = GetComponentInChildren<ShootingModule>();
        interactorModule = GetComponentInChildren<PlayerInteractorModule>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (isLookingAround)
        {
            DoLookAround();
        }
        else if (isWalking)
        {
            DoWalk();
        }
        else
        {
            JumpInput();
            MoveInput();
            LookInput();
            ShootInput();
            InteractInput();
        }
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

    public void EnableLookAround()
    {
        isLookingAround = true;
        characterController.transform.position = new Vector3(94.72f, 0f, 19.56f);
        characterController.transform.eulerAngles = new Vector3(0f, 90f, 0f);
    }

    public void DisableLookAround()
    {
        isLookingAround = false;
    }

    private void DoLookAround()
    {
        lookAroundTimer += Time.deltaTime;
        if (lookAroundTimer < 0.5f)
        {
            characterController.transform.eulerAngles =
                Vector3.Lerp(characterController.transform.eulerAngles, new Vector3(0f, 150f, 0f),
                    lookAroundTimer / 0.5f);
        }
        else if (lookAroundTimer < 1.5f)
        {
            characterController.transform.eulerAngles =
                Vector3.Lerp(characterController.transform.eulerAngles, new Vector3(0f, 30f, 0f),
                    (lookAroundTimer - 0.5f) / 1.5f);
        }
        else if (lookAroundTimer < 2f)
        {
            characterController.transform.eulerAngles =
                Vector3.Lerp(characterController.transform.eulerAngles, new Vector3(0f, 90f, 0f),
                    (lookAroundTimer - 1.5f) / 2f);
        }
    }

    public void EnableWalk()
    {
        isWalking = true;
    }

    public void DisableWalk()
    {
        isWalking = false;
    }

    private void DoWalk()
    {
        walkTimer += Time.deltaTime;
        characterController.transform.position = Vector3.Lerp(characterController.transform.position,
            new Vector3(98f, 0f, 19.56f), walkTimer / 2f);
    }
}
