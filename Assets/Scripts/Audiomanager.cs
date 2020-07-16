using UnityEngine.Audio;
using System;
using UnityEngine;

public class Audiomanager : MonoBehaviour
{
    public static Audiomanager audiomanager;
    public Sounds[] sounds;

    

    // Start is called before the first frame update
    void Awake()
    {
        audiomanager = this;

        foreach (Sounds s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            AudioMixer audioMixer = Resources.Load("AudioMixers/MasterMixer") as AudioMixer;
            if(s.isMusic)
            {
                string musicAudioMixer = "Music";
                s.source.outputAudioMixerGroup = audioMixer.FindMatchingGroups(musicAudioMixer)[0];
            }
            else
            {
                string sfxAudioMixer = "SFX";
                s.source.outputAudioMixerGroup = audioMixer.FindMatchingGroups(sfxAudioMixer)[0];
            }
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loopSound;
            s.source.playOnAwake = s.playAwake;
            
        }
    }

    public void Play(string name)
    {
        //when playing sounds, use this syntax       
        //FindObjectOfType<Audiomanager>().Play("INSERT SOUND NAME");

        Sounds s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
        Debug.Log("Play ssound");
    }

    public void Stop(string name)
    {
        Sounds s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
        Debug.Log("Stop Sound");
    }
}

