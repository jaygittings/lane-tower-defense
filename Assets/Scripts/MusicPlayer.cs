using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    //[SerializeField] AudioClip loadingSound = null;
    //[SerializeField] float volume = .5f;
    [SerializeField] AudioClip[] clips = null;

    AudioSource source = null;
    int currentSongIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        source = GetComponent<AudioSource>();
        source.volume = PlayerPrefsController.GetVolume();

        //AudioSource.PlayClipAtPoint(loadingSound, Camera.main.transform.position, volume);
        source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(!source.isPlaying)
        {
            if(currentSongIndex >= clips.Length)
            {
                currentSongIndex = 0;
            }
            source.clip = clips[currentSongIndex];
            source.Play();
            currentSongIndex++;
        }
    }

    internal void SetVolume(float value)
    {
        source.volume = value;
    }
}
