using UnityEngine;

public class MaskCarrier : MonoBehaviour
{
    public Mask currentMask;

    public delegate void MaskChangeDelegate(Mask newMask);
    public event MaskChangeDelegate OnMaskChanged;

    public void SetMask(Mask mask)
    {
        currentMask = mask;
        OnMaskChanged?.Invoke(currentMask);
    }

    public void SwapMask(MaskCarrier other)
    {
        Mask oldMask = currentMask;
        currentMask = other.currentMask;
        other.currentMask = oldMask;
        OnMaskChanged?.Invoke(currentMask);
        other.OnMaskChanged?.Invoke(other.currentMask);
    }

    public void SwapWithPlayer()
    {
        var playerByTag = GameObject.FindGameObjectWithTag("Player");
        if (playerByTag == null) return;
        MaskCarrier playerMaskCarrier = playerByTag.GetComponent<MaskCarrier>();
        if (playerMaskCarrier == null) return;
        SwapMask(playerMaskCarrier);
    }


    public void SwapMask(GameObject other)
    {
        if(other.GetComponent<MaskCarrier>() == null) return;
        MaskCarrier otherCarrier = other.GetComponent<MaskCarrier>();
        SwapMask(otherCarrier);
    }
}
