using UnityEngine;
using System;
public class AudioManager : MonoBehaviour
{
    bool soundToggle = false;
    public Sound[] sounds;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    // Update is called once per frame
    public void Play(string Name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == Name);
        s.source.Play();
    }

    public void GlassBreak()
    {
        if (soundToggle) Play("GlassBreakSFX1");
        else Play("GlassBreakSFX2");
        soundToggle = !soundToggle;
    }
    public void PauseAllSounds()
    {
        foreach (Sound s in sounds)
        {
            s.source.Pause();
        }
    }
    public void UnPauseAllSounds()
    {
        foreach (Sound s in sounds)
        {
            s.source.UnPause();
        }
    }

}
