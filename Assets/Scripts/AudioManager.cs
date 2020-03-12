using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioSource source;
    public AudioClip[] deathEffects;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayRandomSound()
    {
        source.clip = deathEffects[UnityEngine.Random.Range(0, deathEffects.Length - 1)];
        source.Play();
    }

    internal void Stop()
    {
        if (this.source.isPlaying)
        {
            source.Stop();
        }
    }
}
