using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[RequireComponent(typeof(MaskCarrier))]
public class MaskAnimatorOrquestrator : MonoBehaviour
{
    MaskCarrier maskCarrier;
    MaskCarrier recipient;

    List<MaskAnimator> maskAnimators = new List<MaskAnimator>();

    void OnEnable()
    {
        maskCarrier = GetComponent<MaskCarrier>();
        maskAnimators = new List<MaskAnimator>(GetComponentsInChildren<MaskAnimator>(true));
        maskCarrier.OnMaskChanged += UpdateMaskAnimator;
    }
    void OnDisable()
    {
        maskCarrier.OnMaskChanged -= UpdateMaskAnimator;
    }

    void UpdateMaskAnimator(Mask newMask)
    {
        foreach (var maskAnimator in maskAnimators)
        {
            if (maskAnimator.mask == newMask)
            {
                maskAnimator.gameObject.SetActive(true);
            }
            else
            {
                maskAnimator.gameObject.SetActive(false);
            }
        }
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
        foreach (MaskAnimator maskAnimator in maskAnimators)
        {
            Animator animator = maskAnimator.animator;
            if(animator && animator.enabled && animator.gameObject.activeInHierarchy)
            {
                animator.SetTrigger(param);
            }
        }
    }
}
