using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class InteractableTrigger : MonoBehaviour
{
    private PlayerInputActions input;
    [SerializeField]
    public UnityEvent<GameObject> interactAction;
    public float debounceSeconds = .2f;
    private float lastInteractTime;

	void OnValidate()
	{
		GetComponent<Collider2D>().isTrigger = true;
	}

	void Awake()
    {
        input = new PlayerInputActions();
        input.Player.Enable();
        lastInteractTime = Time.time;
    }

    private bool isInTrigger = false;

    void Update()
    {
        if (input.Player.Act.WasPressedThisFrame() && interactAction != null && isInTrigger)
        {
            if (Time.time - lastInteractTime >= debounceSeconds)
            {
                interactAction.Invoke(gameObject);
                lastInteractTime = Time.time;
            }
        }
    }   


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInTrigger = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInTrigger = false;
        }
    }
}
