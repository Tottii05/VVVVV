using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] AudioSource music;
    [SerializeField] AudioSource sfx;
    public AudioClip menuMusic;
    public AudioClip gameMusic; 
    public AudioClip death;
    public AudioClip jump;
    public AudioClip cannonShot;

    void Awake()
    {
        if (AudioManager.instance == null)
        {
            AudioManager.instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void PlaySFX(AudioClip clip)
    {
        sfx.PlayOneShot(clip);
    }

    public void PlayMusic(AudioClip clip)
    {
        music.clip = clip;
        music.loop = true;
        music.Play();
    }

    public void StopMusic()
    {
        music.Stop();
    }
}
