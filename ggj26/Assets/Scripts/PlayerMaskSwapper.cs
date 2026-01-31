using UnityEngine;


[RequireComponent(typeof(MaskCarrier))]
[RequireComponent(typeof(InteractableTrigger))]
public class PlayerMaskSwapper : MonoBehaviour
{
       private MaskCarrier playerMaskCarrier;
       private MaskAnimatorOrquestrator playerMaskAnimatorOrquestrator;
       private MaskCarrier maskCarrier;
       private InteractableTrigger interactableTrigger;

    void OnEnable()
    {
        var playerByTag = GameObject.FindGameObjectWithTag("Player");
        playerMaskCarrier = playerByTag.GetComponent<MaskCarrier>();
        playerMaskAnimatorOrquestrator = playerByTag.GetComponent<MaskAnimatorOrquestrator>();
        if (playerMaskCarrier == null || playerMaskAnimatorOrquestrator == null)
        {
            Debug.LogError($"Somthing is wrong with the Player object found: {playerByTag.name}");
            return;
        }
        maskCarrier = GetComponent<MaskCarrier>();
        interactableTrigger = GetComponent<InteractableTrigger>();
        interactableTrigger.interactAction.AddListener(HandleInteract);
    }

	void OnDisable()
	{
		interactableTrigger.interactAction.RemoveListener(HandleInteract);
	}

    void HandleInteract(GameObject go)
    {
        if (gameObject != go)
        {
            Debug.LogError($"InteractableTrigger {gameObject.name} invoked on wrong object: " + go.name);
        return;
        }
        playerMaskAnimatorOrquestrator.SwapWithRecipient(maskCarrier);
    }
}
