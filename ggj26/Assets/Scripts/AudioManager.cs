using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;

    public static AudioManager instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds){
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
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
            Debug.Log("Audio "+ SoundName +" não encontrado");
            return;
        }
        s.source.Play();
    }
}
