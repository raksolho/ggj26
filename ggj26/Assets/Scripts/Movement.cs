using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private PlayerInputActions input;
    private Vector2 moveInput;

    public float speed = 5f;

    void Awake()
    {
        input = new PlayerInputActions();
    }

    void OnEnable()
    {
        input.Player.Enable();
    }

    void OnDisable()
    {
        input.Player.Disable();
    }

    void Update()
    {
        moveInput = input.Player.Move.ReadValue<Vector2>();

        Vector3 movement = new Vector3(moveInput.x, moveInput.y, 0);
        transform.Translate(movement * speed * Time.deltaTime);
    }
}
