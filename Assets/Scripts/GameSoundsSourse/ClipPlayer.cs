using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ClipPlayer : MonoBehaviour
{
    [SerializeField] private List<AudioSource> _audioSources;
    [SerializeField] private AudioClip[] _audioClips;

    public void Play()
    {
        AudioSource audioSource = _audioSources.FirstOrDefault(s => s.isPlaying == false);

        if (audioSource != null)
        {
            audioSource.PlayOneShot(GetRandomClip());
        }
        else
        {
            var tempAudioSource = gameObject.AddComponent<AudioSource>();
            tempAudioSource.PlayOneShot(GetRandomClip());
            _audioSources.Add(tempAudioSource);
        }
    }

    private AudioClip GetRandomClip()
    {
        int clipNumber = Random.Range(0, _audioClips.Length);
        return _audioClips[clipNumber];
    }

}
