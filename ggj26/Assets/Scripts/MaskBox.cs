using UnityEngine;
using UnityEngine.Events;

public class MaskBox : MonoBehaviour
{

    MaskCarrier myMaskCarrier;
    MaskCarrier playerMaskCarrier;
    public UnityEvent onBecomeEqual;
    public UnityEvent onBecomeDifferent;
    private bool isEqual = false;
    void OnEnable()
    {
        myMaskCarrier = GetComponentInChildren<MaskCarrier>(true);
        playerMaskCarrier = GameObject.FindGameObjectWithTag("Player").GetComponent<MaskCarrier>();
        myMaskCarrier.OnMaskChanged += UpdateState;
        playerMaskCarrier.OnMaskChanged += UpdateState;
    }

    void OnDisable()
    {
        myMaskCarrier.OnMaskChanged -= UpdateState;
        playerMaskCarrier.OnMaskChanged -= UpdateState;
    }



    void UpdateState(Mask _)
    {
        bool newState = myMaskCarrier.currentMask == playerMaskCarrier.currentMask;
        if (newState != isEqual)
        {
            isEqual = newState;
            if (isEqual)
            {
                onBecomeEqual.Invoke();
            }
            else
            {
                onBecomeDifferent.Invoke();
            }
        }
    }
}
