using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    private AudioSource _audioSource;
    public AudioClip bananasInstrumental;
    public AudioClip bananas;

    private void Awake()
    {
        _audioSource = this.gameObject.AddComponent<AudioSource>();
        StartCoroutine(PlayBananas());
    }

    IEnumerator PlayInstrumental()
    {
        _audioSource.PlayOneShot(bananasInstrumental);
        
        do {
            yield return new WaitForSeconds(0.1f);
        } while (_audioSource.isPlaying);

        yield return new WaitForSeconds(10);
        StartCoroutine(PlayBananas());
    }
    
    IEnumerator PlayBananas()
    {
        _audioSource.PlayOneShot(bananas);
        
        do {
            yield return new WaitForSeconds(0.1f);
        } while (_audioSource.isPlaying);

        yield return new WaitForSeconds(10);
        StartCoroutine(PlayInstrumental());
    }
}
