using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueTrigger : MonoBehaviour {

	public Dialogue dialogue;

	public void TriggerDialogue ()
	{
		FindFirstObjectByType<DialogueManager>().StartDialogue(dialogue);
	}

    void Update()
    {
        DialogueManager dialogueManager = FindFirstObjectByType<DialogueManager>();
        
        if (dialogueManager.IsDialogueActive())
        {
            if (Keyboard.current.eKey.wasPressedThisFrame)
            {
                dialogueManager.DisplayNextSentence();
            }
        }
        else if (dialogue != null && Keyboard.current.eKey.wasPressedThisFrame)
        {
            TriggerDialogue();
        }
    }

}