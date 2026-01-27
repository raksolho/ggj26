using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private PlayerInputActions input;
    private Vector2 moveInput;
    private Animator animator;
    private Rigidbody2D rb;
    public float speed = 5f;

    void Awake()
    {
        input = new PlayerInputActions();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
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
        
        UpdateAnimation();
        rb.linearVelocity = movement * speed;
    }


   void UpdateAnimation()
{
    Vector2 dir = moveInput  ;
    if (dir.magnitude < 0.15f)
        return;

    animator.SetBool("WalkFront", false);
    animator.SetBool("WalkBack", false);
    animator.SetBool("WalkSide", false);

    if (Mathf.Abs(dir.y) >= Mathf.Abs(dir.x) * 1.2f)
    {
        if (dir.y > 0)
            animator.SetBool("WalkBack", true);
        else
            animator.SetBool("WalkFront", true);
    }
    else
    {
        animator.SetBool("WalkSide", true);
        transform.localScale = new Vector3(dir.x > 0 ? 1 : -1, 1, 1);
    }
}

    
}
