using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueTrigger : MonoBehaviour
{

    public delegate void DialogueChangeDelegate(Dialogue newDialogue);
    public event DialogueChangeDelegate OnDialogueStarted;
    public event DialogueChangeDelegate OnDialogueEnded;
    private PlayerInputActions input;
    public Dialogue dialogue;
    DialogueManager dialogueManager;
    bool forceStart = false;


    void Awake()
    {
        dialogueManager = FindFirstObjectByType<DialogueManager>();
        input = new PlayerInputActions();
        input.Player.Enable();
        forceStart=dialogue.forceStart;
    }
    public void TriggerDialogue()
    {
        FindFirstObjectByType<DialogueManager>().StartDialogue(dialogue);
    }
    private bool isInTrigger = false;

    void Update()
    {
        if ((forceStart || input.Player.Act.WasPressedThisFrame()) && dialogueManager != null && isInTrigger)
        {
            forceStart=false;
            if (dialogueManager.IsDialogueActive())
            {
                if (dialogueManager.getRemainingSentences() == 0)
                {
                    OnDialogueEnded?.Invoke(dialogue);
                }
                dialogueManager.DisplayNextSentence();

            }
            else if (dialogue != null)
            {
                TriggerDialogue();
                OnDialogueStarted?.Invoke(dialogue);
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