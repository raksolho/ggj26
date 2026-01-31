using System.Collections;
using System.Collections.Generic;
using Assets.SimpleLocalization.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
   

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public GameObject dialoguePanel;

    public Queue<string> LocationKeys;
    private bool isDialogueActive = false;

    private Movement movement;

    // Use this for initialization
    void Start()
    {
        LocationKeys = new Queue<string>();
        movement = FindObjectOfType<Movement>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        movement.StopMovement();
        movement.enabled = false;
        dialoguePanel.SetActive(true);
        isDialogueActive = true;
        nameText.text = dialogue.name;

        LocationKeys.Clear();

        foreach (string Key in dialogue.LocationKeys)
        {
            LocationKeys.Enqueue(LocalizationManager.Localize(Key));
        }

        DisplayNextSentence();
    }
     public int getRemainingSentences()
    {
        return  LocationKeys.Count;
    }
    public void DisplayNextSentence()
    {
        if (getRemainingSentences() == 0)
        {
            EndDialogue();
            return;
        }

        string Key = LocationKeys.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(Key));
    }

    IEnumerator TypeSentence(string Key)
    {
        dialogueText.text = "";
        foreach (char letter in Key.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.02f);
        }
    }

    void EndDialogue()
    {
        dialoguePanel.SetActive(false);
        isDialogueActive = false;
        movement.enabled = true;
        Debug.Log("End of conversation.");
    }

    public bool IsDialogueActive()
    {
        return isDialogueActive;
    }

}