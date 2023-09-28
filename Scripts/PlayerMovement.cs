using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    PlayerInput playerInput;
    InputAction moveAction;

    public float speed;
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
        Vector3 movement = new Vector3(direction.x * speed, 0, direction.y * speed) * Time.deltaTime;
        transform.position += movement;

        // Menghitung tilt (kemiringan) berdasarkan input horizontal
        float tilt = direction.x * -tiltAmount;

        // Mengatur rotasi objek
        Quaternion targetRotation = Quaternion.Euler(0, 0, tilt);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
