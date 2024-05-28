using UnityEngine;

[CreateAssetMenu(fileName = "AudioConfig", menuName = "Audio/AudioConfig", order = 2)]
public class AudioConfig : ScriptableObject
{
    public AudioClip AudioClip;
    public AllNameSignal Signal;
}
