using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static PlayerInputActions;

public class OpenMenu : MonoBehaviour, IPlayerActions
{
    private PlayerInputActions input;
    public GameObject pauseMenuUI;
    public Movement playerMovement;


    void Awake()
    {
        input = new PlayerInputActions();

    }

    void OnEnable()
    {
        input.Player.Enable();
        input.Player.AddCallbacks(this);                      // Register callback interface IPlayerActions.
    }

    void OnDisable()
    {
        input.Player.Disable();
    }

    public void OnMove(InputAction.CallbackContext _context)
    {
        //ignored
    }

    public void OnAct(InputAction.CallbackContext _context)
    {
        //ignored
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            pauseMenuUI.SetActive(!pauseMenuUI.activeSelf);
            Time.timeScale = pauseMenuUI.activeSelf ? 0f : 1f;
            playerMovement.enabled = !pauseMenuUI.activeSelf;
        }
    }
}
