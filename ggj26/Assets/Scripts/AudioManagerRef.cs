using UnityEngine;
using UnityEngine.UI;

public class AudioManagerRef : MonoBehaviour
{
    public Slider volumeSlider;


    void Start()
    {
        if (volumeSlider == null) return;
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume", 1);
    }
    public void Play(string SoundName)
    {
        AudioManager.instance.Play(SoundName);

    }

    public void ChangeVolume(float volume)
    {
        AudioManager.instance.ChangeVolume(volume);
    }
}
