using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundSettingController : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = GlobalSettingSound.SoundVolume;
    }
}
