using UnityEngine;

public class BackgroundMusicController : MonoBehaviour
{
    [SerializeField] private AudioSource _backgroundMusic;

    private void Awake()
    {
        _backgroundMusic.volume = GlobalSettingSound.MusicVolume;
    }
}
