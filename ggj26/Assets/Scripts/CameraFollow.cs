using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public MaskCarrier maskCarrier;

    Movement player;
    bool followPlayer = true;
    public Vector3 offset= new Vector3(0,0,-10);
    public float smoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
 
        player = FindObjectOfType<Movement>();
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
        if (player != null && followPlayer)
        {
            Vector3 desiredPosition = new Vector3(player.transform.position.x, player.transform.position.y, -10) ;
            transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothTime);
        }
    }
    // void Update()
    // {
    //     if (player != null && followPlayer)
    //     {
    //         Vector3 newPos = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
    //         transform.position = newPos;
    //     }

    // }
    void setFollowPlayer(Mask mask)
    {
        followPlayer = mask?.followCamera ?? true;
    }
}
