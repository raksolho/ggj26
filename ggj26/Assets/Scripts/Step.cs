using Unity.Collections;
using UnityEngine;

public class Step : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip stepSound;
    public AudioClip swimSound;
    SpriteRenderer spriteRenderer;

    void Awake()
    {
        audioSource = GetComponentInParent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void StepNoise()
    {
        if (spriteRenderer.enabled == false) return;
        audioSource.pitch = Random.Range(0.8f, 1.2f);
        audioSource.PlayOneShot(stepSound);
    }

    public void SwimNoise()
    {
        if (spriteRenderer.enabled == false) return;
        audioSource.pitch = Random.Range(0.8f, 1.2f);
        audioSource.PlayOneShot(swimSound);
    }
}
