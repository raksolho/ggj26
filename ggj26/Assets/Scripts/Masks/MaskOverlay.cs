using UnityEngine;
using UnityEngine.UI;
public class MaskOverlay : MonoBehaviour
{
    public Image image;
    public MaskCarrier maskCarrier;


    void OnEnable()
    {
        maskCarrier.OnMaskChanged += SetMaskOverlay;
    }

    void OnDisable()
    {
        maskCarrier.OnMaskChanged -= SetMaskOverlay;
    }


    public void SetMaskOverlay(Mask mask)
    {
        if (mask != null)
        {
            image.gameObject.SetActive(true);
            Debug.Log("" + mask);
            image.sprite = mask.maskOverlay;

        }
        else
        {
            image.gameObject.SetActive(false);
        }
        
    }
}
