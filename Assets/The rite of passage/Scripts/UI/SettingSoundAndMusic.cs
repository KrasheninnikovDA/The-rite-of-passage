using UnityEngine;

public class SettingSoundAndMusic : MonoBehaviour
{
    private void Start()
    {
        GlobalSettingSound.MusicVolume = 1;
        GlobalSettingSound.SoundVolume = 1; 
    }

    public void MusicSliderChange(float value)
    {
        GlobalSettingSound.MusicVolume = value;
    }

    public void SoundSliderChange(float value)
    {
        GlobalSettingSound.SoundVolume = value;
    }
}
