using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayOneShotAudio : MonoBehaviour
{
    [SerializeField]
    AudioClip clip = null;

    AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public void PlayAudio()
    {
        source.PlayOneShot(clip);
    }
}
