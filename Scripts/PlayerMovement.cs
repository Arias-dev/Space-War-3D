using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    PlayerInput playerInput;
    InputAction moveAction;

    public float speed;
    public float speedInput;
    public float rotationSpeed;
    public float tiltAmount;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions.FindAction("Movements");
    }

    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        Vector2 direction = moveAction.ReadValue<Vector2>();
        Vector3 movement = new Vector3(direction.x * speedInput, 0, direction.y * speedInput) * Time.deltaTime;
        transform.position += movement;

        float tilt = direction.x * -tiltAmount;
        Quaternion targetRotation = Quaternion.Euler(0, 0, tilt);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        // Pemain bergerak maju
        Vector3 movementForward = transform.forward * speed * Time.deltaTime;
        transform.position += movementForward;
    }
}
