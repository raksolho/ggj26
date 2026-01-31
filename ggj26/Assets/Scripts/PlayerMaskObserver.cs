using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMaskObserver : MonoBehaviour
{
    private MaskCarrier maskCarrier;
    public List<Mask> observedMasks;
    public UnityEvent onObtainedObservedMask;
    public UnityEvent onLostObservedMask;
    void OnEnable()
    {
        var playerByTag = GameObject.FindGameObjectWithTag("Player");
        maskCarrier = playerByTag.GetComponent<MaskCarrier>();
        if (maskCarrier == null)
        {
            Debug.LogError("PlayerMaskObserver: No MaskCarrier found on Player");
            return;
        }
        maskCarrier.OnMaskChanged += HandleMaskChanged;
    }

    void OnDisable()
    {
        if (maskCarrier != null)
        {
            maskCarrier.OnMaskChanged -= HandleMaskChanged;
        }
    }

    void HandleMaskChanged(Mask newMask)
    {
        if (observedMasks.Contains(newMask))
        {
            onObtainedObservedMask.Invoke();
        }
        else
        {
            onLostObservedMask.Invoke();
        }
    }
}
