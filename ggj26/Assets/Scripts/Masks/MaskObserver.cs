using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MaskObserver : MonoBehaviour
{
    public MaskCarrier maskCarrier;
    public List<Mask>  observedMasks;
    public UnityEvent onObtainedObservedMask;
    public UnityEvent onLostObservedMask;
    void OnEnable()
    {
        maskCarrier.OnMaskChanged += HandleMaskChanged;
    }

    void OnDisable()
    {
        maskCarrier.OnMaskChanged -= HandleMaskChanged;
    }

    void HandleMaskChanged(Mask newMask)
    {
        if(observedMasks.Contains(newMask))
        {
            onObtainedObservedMask.Invoke();
        }
        else
        {
            onLostObservedMask.Invoke();
        }
    }
}
