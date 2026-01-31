using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[RequireComponent(typeof(MaskCarrier))]
public class MaskAnimatorOrquestrator : MonoBehaviour
{
    MaskCarrier maskCarrier;
    MaskCarrier recipient;

    List<MaskAnimator> maskAnimators = new List<MaskAnimator>();

    bool swappingMasks = false;

    void OnEnable()
    {
        swappingMasks = false;
        maskCarrier = GetComponent<MaskCarrier>();
        maskAnimators = new List<MaskAnimator>(GetComponentsInChildren<MaskAnimator>(true));
    }

    public void SwapWithRecipient(MaskCarrier recipient)
    {
        if (swappingMasks || recipient == null) return;
        SetNextRecipient(recipient);
        RemoveMaskAnimation();
    }


    public void HandleMaskRemove()
    {
        swappingMasks = true;
        StartCoroutine(DelayedHandleMaskChange(recipient));
    }

    private IEnumerator DelayedHandleMaskChange(MaskCarrier recipient)
    {
        Mask oldMask = maskCarrier.currentMask;
        Mask newMask = recipient.currentMask;
        MaskAnimator activeMaskAnimator = UpdateActiveMaskAnimator(recipient.currentMask);
        maskCarrier.SetMask(null);
        yield return null;
        yield return new WaitUntil(
            () => activeMaskAnimator.animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f
        );
        maskCarrier.SetMask(newMask);
        recipient.SetMask(oldMask);
        swappingMasks = false;
    }

    private MaskAnimator UpdateActiveMaskAnimator(Mask newMask)
    {
        MaskAnimator activeMaskAnimator = null;
        foreach (var maskAnimator in maskAnimators)
        {
            if (maskAnimator.mask == newMask)
            {
                maskAnimator.gameObject.SetActive(true);
                activeMaskAnimator = maskAnimator;
            }
            else
            {
                maskAnimator.gameObject.SetActive(false);
            }
        }
        return activeMaskAnimator;
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
        foreach (MaskAnimator maskAnimator in maskAnimators)
        {
            Animator animator = maskAnimator.animator;
            if (animator && animator.enabled && animator.gameObject.activeInHierarchy)
            {
                animator.SetTrigger(param);
            }
        }
    }
}
