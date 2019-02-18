using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour {

    public AudioSource audioSource;
    public AudioClip[] clips;

    void Start()
    {
        StartCoroutine(Play());
    }

    IEnumerator Play()
    {
        foreach (AudioClip clip in clips)
        {
            audioSource.clip = clip;
            audioSource.Play();
            yield return new WaitForSeconds(audioSource.clip.length);
        }
        StartCoroutine(Play());
    }
}
