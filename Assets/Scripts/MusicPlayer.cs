using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] AudioClip loadingSound = null;
    [SerializeField] float volume = .5f;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource.PlayClipAtPoint(loadingSound, Camera.main.transform.position, volume);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
