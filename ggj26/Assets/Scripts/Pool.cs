using UnityEngine;

public class Pool : MonoBehaviour
{
    public MaskCarrier player;
    public GameObject swimmingSprite;
    public GameObject walkingSprite;

    public static int poolCount = 0;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && player.currentMask?.name == "WaterMask")
        {
            poolCount += 1;
            if (poolCount >= 1)
            {
                swimmingSprite.GetComponent<SpriteRenderer>().enabled = true;
                walkingSprite.GetComponent<SpriteRenderer>().enabled = false;
            }

        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player" && player.currentMask?.name == "WaterMask")
        {
            poolCount -= 1;
            if (poolCount <= 0)
            {
                swimmingSprite.GetComponent<SpriteRenderer>().enabled = false;
                walkingSprite.GetComponent<SpriteRenderer>().enabled = true;

            }
        }

    }

}
