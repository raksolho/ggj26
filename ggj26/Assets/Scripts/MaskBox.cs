using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(SpriteRenderer))]
public class MaskBox : MonoBehaviour
{

    MaskCarrier myMaskCarrier;
    MaskCarrier playerMaskCarrier;
    public UnityEvent onBecomeEqual;
    public UnityEvent onBecomeDifferent;
    private bool isEqual = false;
    SpriteRenderer myRenderer;
    Sprite originalSprite;


    void Awake()
    {
        myMaskCarrier = GetComponentInChildren<MaskCarrier>(true);
        myRenderer = GetComponent<SpriteRenderer>();
        originalSprite = myRenderer.sprite;
    }

    void OnEnable()
    {
        playerMaskCarrier = GameObject.FindGameObjectWithTag("Player").GetComponent<MaskCarrier>();
        myMaskCarrier.OnMaskChanged += UpdateState;
        myMaskCarrier.OnMaskChanged += UpdateSprite;
        playerMaskCarrier.OnMaskChanged += UpdateState;
        UpdateSprite(myMaskCarrier.currentMask);
        UpdateState(null);
    }

    void OnDisable()
    {
        myMaskCarrier.OnMaskChanged -= UpdateState;
        myMaskCarrier.OnMaskChanged -= UpdateSprite;
        playerMaskCarrier.OnMaskChanged -= UpdateState;
    }


    void UpdateSprite(Mask m)
    {
        Debug.Log("Updating MaskBox sprite");
        if (myMaskCarrier.currentMask != null)
        {
            Debug.Log("Setting sprite to box sprite " + myMaskCarrier.currentMask.boxSprite);
            myRenderer.sprite = myMaskCarrier.currentMask.boxSprite;
        }
        else
        {
            myRenderer.sprite = originalSprite;
        }
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
