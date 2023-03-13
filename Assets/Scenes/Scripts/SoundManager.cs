using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    [SerializeField] private AudioSource effectSource; 

    void Awake()
    {
        if(Instance == null)
        { 
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {Destroy(gameObject);}

    }
    public void PlaySound (AudioClip clip)
    {
        effectSource.PlayOneShot(clip);
    }
    public void PauseSound (AudioClip clip)
    {
        effectSource.Pause();
    }
    public void ChangeMasterVolume(float value)
    {
        AudioListener.volume = value;
    }
}
