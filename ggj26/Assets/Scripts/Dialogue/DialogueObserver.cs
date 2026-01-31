using UnityEngine;
using UnityEngine.Events;

public class DialogueObserver : MonoBehaviour
{
    public DialogueTrigger dialogueTrigger;


    public UnityEvent onDialogueStartEvent;
    public UnityEvent onDialogueEndEvent;
    void Start()
    {
    }

    void OnEnable()
    {
        dialogueTrigger.OnDialogueStarted += onDialogueStarted;
        dialogueTrigger.OnDialogueEnded += onDialogueEnded;
    }

    void OnDisable()
    {
        dialogueTrigger.OnDialogueStarted -= onDialogueStarted;
        dialogueTrigger.OnDialogueEnded -= onDialogueEnded;
    }
    public void onDialogueStarted(Dialogue dialogue)
    {
        onDialogueStartEvent.Invoke();
    }
    public void onDialogueEnded(Dialogue dialogue)
    {
        onDialogueEndEvent.Invoke();
    }

}
