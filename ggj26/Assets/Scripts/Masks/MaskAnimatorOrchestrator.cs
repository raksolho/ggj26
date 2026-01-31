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

    MaskAnimator activeMaskAnimator;

    void OnEnable()
    {
        swappingMasks = false;
        maskCarrier = GetComponent<MaskCarrier>();
        maskAnimators = new List<MaskAnimator>(GetComponentsInChildren<MaskAnimator>(true));
        UpdateActiveMaskAnimator(maskCarrier.currentMask);
    }

    public void SwapWithRecipient(MaskCarrier recipient)
    {
        if (swappingMasks || recipient == null) return;
        StartCoroutine(DelayedMaskSwap(recipient));
    }


    public void HandleMaskRemove()
    {
        swappingMasks = true;
    }

    private IEnumerator DelayedMaskSwap(MaskCarrier recipient)
    {
        Debug.Log("Swapping start...");
        swappingMasks = true;
        Mask oldMask = maskCarrier.currentMask;
        Mask newMask = recipient.currentMask;
        RemoveMaskAnimation();
        yield return null;
        var animStateHash = activeMaskAnimator.animator.GetCurrentAnimatorStateInfo(0).shortNameHash;
        Debug.Log("Waiting for remove mask animation to finish");
        yield return new WaitUntil(
        () => activeMaskAnimator.animator.GetCurrentAnimatorStateInfo(0).shortNameHash != animStateHash
        || activeMaskAnimator.animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f);

        // if cancelled animation
        if (activeMaskAnimator.animator.GetCurrentAnimatorStateInfo(0).shortNameHash != animStateHash)
        {
            Debug.Log("Cancelled mask swap");
            swappingMasks = false;
            yield break;
        }


        UpdateActiveMaskAnimator(recipient.currentMask);
        maskCarrier.SetMask(null);
        yield return null;
        animStateHash = activeMaskAnimator.animator.GetCurrentAnimatorStateInfo(0).shortNameHash;
        Debug.Log("Waiting for put mask animation to finish");
        yield return new WaitUntil(
            () => activeMaskAnimator.animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f
            || activeMaskAnimator.animator.GetCurrentAnimatorStateInfo(0).shortNameHash != animStateHash
        );
        maskCarrier.SetMask(newMask);
        recipient.SetMask(oldMask);
        swappingMasks = false;
        Debug.Log("Swapping end.");
    }

    private MaskAnimator UpdateActiveMaskAnimator(Mask newMask)
    {
        MaskAnimator activeMaskAnimator = null;
        foreach (var maskAnimator in maskAnimators)
        {
            if (maskAnimator.mask == newMask)
            {
                maskAnimator.enabled = true;
                activeMaskAnimator = maskAnimator;
            }
            else
            {
                maskAnimator.enabled = false;
            }
        }
        this.activeMaskAnimator = activeMaskAnimator;
        return activeMaskAnimator;
    }

    private void SetNextRecipient(MaskCarrier maskCarrier)
    {
        recipient = maskCarrier;

    }
    private void RemoveMaskAnimation()
    {
        activeMaskAnimator.animator.SetTrigger("removeMask");
    }
}
