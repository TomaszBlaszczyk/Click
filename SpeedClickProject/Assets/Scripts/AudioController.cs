using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : Singleton<AudioController>
{
    public AudioSource audioSource;

    public AudioClip correctSound;
    public AudioClip wrongSound;

    public void PlayCorrectSound()
    {
        audioSource.PlayOneShot(correctSound);
    }

    public void PlayWrongSound()
    {
        audioSource.PlayOneShot(wrongSound);
    }
}
