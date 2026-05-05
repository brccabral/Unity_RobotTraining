using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector3 movementDirection;

    private CharacterController characterController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        movementDirection.x = Input.GetAxisRaw("Horizontal");
        movementDirection.z = Input.GetAxisRaw("Vertical");
        movementDirection = movementDirection.normalized;

        characterController.Move(movementDirection * Time.deltaTime);
    }
}
