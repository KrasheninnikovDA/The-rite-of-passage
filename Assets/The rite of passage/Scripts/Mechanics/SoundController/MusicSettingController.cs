using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicSettingController : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = GlobalSettingSound.MusicVolume;
    }

    private void Update()
    {
        _audioSource.volume = GlobalSettingSound.MusicVolume;
    }
}
