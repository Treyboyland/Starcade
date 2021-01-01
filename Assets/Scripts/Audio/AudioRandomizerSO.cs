using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RandomAudio", menuName = "Misc/Random Audio")]
public class AudioRandomizerSO : ScriptableObject
{
    [SerializeField]
    List<AudioClip> clips = new List<AudioClip>();

    [SerializeField]
    Vector2 volumeRange = new Vector2();

    [SerializeField]
    Vector2 pitchRange = new Vector2();

    public void PlayRandomSound(AudioSource source)
    {
        var clip = clips[Random.Range(0, clips.Count)];
        var pitch = Random.Range(pitchRange.x, pitchRange.y);
        var volume = Random.Range(volumeRange.x, volumeRange.y);
        source.pitch = pitch;
        source.PlayOneShot(clip, volume);
    }
}
