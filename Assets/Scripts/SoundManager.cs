using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public AudioSource musicSource;
    public AudioSource sfxSource;

    public float lowPitchRange = 0.95f;
    public float highPitchRange = 1.05f;

    public static SoundManager instance;


//Singleton//
    private void Awake()
    {
        if (SoundManager.instance == null)
        {
            SoundManager.instance = this;
        }
        else
        {
            if (SoundManager.instance != this)
            {
                Destroy(gameObject);
            }

            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlaySingle (AudiClip clip)
    {
        sfxSource.clip = clip;
        sfxSource.Play();

    }

    public void RandomizeSfx(params AudiClip [] clips)
    {
        int randomIndex = Random.Range (0, clips.Length);
float randomPPitch = Random.Rabge(lowPitchRange, highPitchRange);
sfxSource

        sfxSource.clip = clips[randomIndex];
        sfxSource.Play();
    }
   
}
