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

    private Queue<string> LocationKeys;
    private bool isDialogueActive = false;

    // Use this for initialization
    void Start()
    {
        LocationKeys = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
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

    public void DisplayNextSentence()
    {
        if (LocationKeys.Count == 0)
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
        Debug.Log("End of conversation.");
    }

    public bool IsDialogueActive()
    {
        return isDialogueActive;
    }

}