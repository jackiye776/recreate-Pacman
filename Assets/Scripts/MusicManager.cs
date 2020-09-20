using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip introMusic;
    public AudioClip ghostNormalMusic;

    // Start is called before the first frame update
    void Start()
    {
        audioSource.Play();

    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = ghostNormalMusic;
            audioSource.Play();
        }
    }
}
