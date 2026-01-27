using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueTrigger : MonoBehaviour
{

    private PlayerInputActions input;
    public Dialogue dialogue;
    DialogueManager dialogueManager;


    void Awake()
    {
        dialogueManager = FindFirstObjectByType<DialogueManager>();
        input = new PlayerInputActions();
        input.Player.Enable();
    }
    public void TriggerDialogue()
    {
        FindFirstObjectByType<DialogueManager>().StartDialogue(dialogue);
    }
    private bool isInTrigger = false;

    void Update()
    {
        if (input.Player.Act.WasPressedThisFrame() && dialogueManager != null && isInTrigger)
        {
            if (dialogueManager.IsDialogueActive())
            {
                dialogueManager.DisplayNextSentence();
            }
            else if (dialogue != null)
            {
                TriggerDialogue();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInTrigger = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInTrigger = false;
        }
    }
}