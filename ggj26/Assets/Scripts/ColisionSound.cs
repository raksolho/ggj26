using UnityEngine;

public class ColisionSound : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip colisionSound;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayColisionSound()
    {
        audioSource.pitch = Random.Range(0.8f, 1.2f);
        audioSource.PlayOneShot(colisionSound);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayColisionSound();
    }
}
