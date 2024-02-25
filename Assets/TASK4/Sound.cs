using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioClip shootSFX;
    AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void PlayShootSound()
    {
        source.PlayOneShot(shootSFX);
    }
        
}
