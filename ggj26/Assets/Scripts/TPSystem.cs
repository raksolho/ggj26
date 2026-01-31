using Unity.VisualScripting;
using UnityEngine;

public class TPSystem : MonoBehaviour
{
    
    public Transform exit;
    private CameraFollow cameraFollow;

    void Start()
    {
        cameraFollow = Camera.main.GetComponent<CameraFollow>();
    }

   
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Teleporting");
            collision.transform.position = exit.transform.position;
            cameraFollow.followPlayer = true;
            
        }
    }


}
