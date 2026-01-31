using UnityEngine;

public class Pool : MonoBehaviour
{
    public MaskCarrier player;
    public GameObject swimmingSprite;
    public GameObject walkingSprite;


    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player" && player.currentMask?.name == "WaterMask"){
            swimmingSprite.GetComponent<SpriteRenderer>().enabled = true;
            walkingSprite.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player" && player.currentMask?.name == "WaterMask"){
            swimmingSprite.GetComponent<SpriteRenderer>().enabled = false;
            walkingSprite.GetComponent<SpriteRenderer>().enabled = true;
        }
        
    }

}
