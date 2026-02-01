using UnityEngine;
using UnityEngine.Playables;

public class CutsceneTrigger : MonoBehaviour
{

    public PlayableDirector cutscene;




   
     void OnTriggerEnter2D(Collider2D other)
     {
       if (other.CompareTag("Player"))
        {
             cutscene.Play();
        }  
     }
}
