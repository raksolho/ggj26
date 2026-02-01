using Unity.Collections;
using UnityEngine;

public class Step : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip stepSound;
    void Awake()
    {
        audioSource = GetComponentInParent<AudioSource>();
    }

    public void StepNoise()
    {
        audioSource.pitch = Random.Range(0.8f, 1.2f);
        audioSource.PlayOneShot(stepSound);
    }
}
