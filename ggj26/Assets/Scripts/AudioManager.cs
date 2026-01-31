using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;

    void Awake()
    {
        foreach (Sound s in sounds){
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;

        }
    }

    void Start()
    {
        Play("Theme");
    }

    public void Play(string SoundName)
    {
        Sound s = Array.Find(sounds, sound => sound.name == SoundName);
        if(s == null)
        {
            Debug.Log("Audio não encontrado");
            return;
        }
        s.source.Play();
    }
}
