using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundController : MonoBehaviour
{
    [SerializeField] private AudioConfig[] _audioConfigs;

    private AudioSource _audioSource;
    protected Dictionary<AllNameSignal, AudioClip> _audioMap = new();

    public void Construct(SignalHolder signalHolder)
    {
        signalHolder.SignalForSoundController.Subscribe(Switch);
        _audioSource = GetComponent<AudioSource>();
        ConstructAudioMap();
    }

    public void Switch(AllNameSignal signal)
    {
        if (_audioMap.TryGetValue(signal, out AudioClip audioClip))
        {
            _audioSource.clip = audioClip;
            _audioSource.volume = GlobalSettingSound.SoundVolume;
            _audioSource.Play();
        }
    }

    private void ConstructAudioMap()
    {
        foreach (AudioConfig audioConfig in _audioConfigs)
        {
            _audioMap.Add(audioConfig.Signal, audioConfig.AudioClip);
        }
    }
}
