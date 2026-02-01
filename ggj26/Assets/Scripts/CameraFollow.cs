using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public MaskCarrier maskCarrier;

    public float ythreshold;

    Movement player;
    public bool followPlayer = false;
    public Vector3 offset = new Vector3(0, 10, -10);
    public float smoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        player = FindAnyObjectByType<Movement>();
    }


    void OnEnable()
    {

        maskCarrier.OnMaskChanged += setFollowPlayer;
    }

    void OnDisable()
    {
        maskCarrier.OnMaskChanged -= setFollowPlayer;
    }
    // Update is called once per frame

    void Update()
    {
        if (player != null)
        {
            if(player.transform.position.y > ythreshold)
            {
                followPlayer = false;
            }
            if (followPlayer)
            {
                Vector3 desiredPosition = new Vector3(player.transform.position.x, player.transform.position.y, -10) + offset;
                transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothTime);
            }
            else
            {
                Vector3 desiredPosition = GetMaskOffset(player);
                transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothTime);
            }
        }
    }

    Vector3 GetMaskOffset(Movement m)
    {
        if(m.transform.position.y <= ythreshold)
        {
            return maskCarrier.currentMask?.positionOffset ?? new Vector3(0, 0, -10);
        }
        else
        {
            followPlayer = false;

            return maskCarrier.currentMask?.positionOffset2 ?? new Vector3(0, 0, -10);
        }
    }

    void setFollowPlayer(Mask mask)
    {
        followPlayer = mask?.followCamera ?? false;
    }
}
