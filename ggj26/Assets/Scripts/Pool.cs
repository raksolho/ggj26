using UnityEngine;

public class Pool : MonoBehaviour
{
    public MaskCarrier player;
    public GameObject swimmingSprite;
    public GameObject walkingSprite;


    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player" && player.currentMask?.name == "WaterMask"){
            swimmingSprite.SetActive(true);
            walkingSprite.SetActive(false);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player" && player.currentMask?.name == "WaterMask"){
            swimmingSprite.SetActive(false);
            walkingSprite.SetActive(true);
        }
        
    }

}
