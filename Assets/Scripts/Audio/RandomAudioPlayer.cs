using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class RandomAudioPlayer : MonoBehaviour
{
    [SerializeField]
    AudioRandomizerSO audioRandomizerSO = null;
    AudioSource source;
    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public void PlayRandomAudio()
    {
        Debug.LogWarning("Playing Audio");
        if (source != null)
        {
            audioRandomizerSO.PlayRandomSound(source);
        }
    }
}
