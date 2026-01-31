using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private PlayerInputActions input;
    private Vector2 moveInput;
    private List<Animator> animators;
    private Rigidbody2D rb;
    public float speed = 5f;

    void Awake()
    {
        input = new PlayerInputActions();
        animators = new List<Animator>(GetComponentsInChildren<Animator>(true));
        rb = GetComponentInChildren<Rigidbody2D>();
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
        Vector2 dir = moveInput;

       ResetAnimations();

        if (dir.magnitude < 0.15f)
        {
            return;
        }

        if (Mathf.Abs(dir.y) >= Mathf.Abs(dir.x) * 1.2f)
        {
            if (dir.y > 0)
                SetBoolForAllAnimators("WalkBack", true);
            else
                SetBoolForAllAnimators("WalkFront", true);
        }
        else
        {
            SetBoolForAllAnimators("WalkSide", true);
            transform.localScale = new Vector3(dir.x > 0 ? -1 : 1, 1, 1);
        }
    }
    private void ResetAnimations()
    {
        SetBoolForAllAnimators("WalkFront", false);
        SetBoolForAllAnimators("WalkBack", false);
        SetBoolForAllAnimators("WalkSide", false);
    }
    public void StopMovement()

    {
        ResetAnimations();
        rb.linearVelocity = Vector2.zero;
    }
    private void SetBoolForAllAnimators(string param, bool value)
    {
        foreach (Animator animator in animators)
        {
            if(animator.enabled && animator.gameObject.activeInHierarchy && animator.runtimeAnimatorController != null)
            {
                animator.SetBool(param, value);
            }
        }
    }

}
