using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[RequireComponent(typeof(MaskCarrier))]
public class MaskAnimator : MonoBehaviour
{
    MaskCarrier maskCarrier;
    MaskCarrier recipient;
    private List<Animator> animators;

    void Start()
    {
        maskCarrier = GetComponent<MaskCarrier>();

        animators = new List<Animator>(GetComponentsInChildren<Animator>(true));

    }


    public void HandleMaskRemove()
    {
        maskCarrier.SwapMask(recipient);
    }
    public void SetNextRecipient(MaskCarrier maskCarrier)
    {
        recipient = maskCarrier;

    }
    public void RemoveMaskAnimation()
    {
            SetTriggerForAllAnimators("removeMask");

    }
    private void SetTriggerForAllAnimators(string param)
    {
        foreach (Animator animator in animators)
        {
            if(animator.enabled && animator.gameObject.activeInHierarchy)
            {
                animator.SetTrigger(param);
            }
        }
    }
}
