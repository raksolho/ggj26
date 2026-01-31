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
        var player = GameObject.Find("Player");
        maskCarrier = playerByTag.GetComponent<MaskCarrier>();
        var maskCarrier2 = player.GetComponent<MaskCarrier>();
        Debug.Log($"    PlayerMaskObserver: Found player object: {player}");
        Debug.Log($"player.tag{player.tag}");
        Debug.Log($"player.tag{player.name}");
        Debug.Log($"playerByTag.tag{playerByTag.tag}");
        Debug.Log($"playerByTag.tag{playerByTag.name}");
        Debug.Log($"maskCarrier{maskCarrier}");
        Debug.Log($"maskCarrier2{maskCarrier2}");
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
