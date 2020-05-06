using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource audioSrc;
    private float musicVolume = 1f;

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();    
    }

    // Update is called once per frame
    void Update()
    {
        audioSrc.volume = musicVolume;
    }

    public void SeVolume(float vol)
    {
        musicVolume = vol;
    }
}
