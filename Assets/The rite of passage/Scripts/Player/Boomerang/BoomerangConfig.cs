using UnityEngine;

[CreateAssetMenu(fileName = "BoomerangConfig", menuName = "Shell/BoomerangConfig", order = 1)]
public class BoomerangConfig : ScriptableObject
{
    [SerializeField, Range(0.5f,5f)] private float _distance;
    [SerializeField, Range(0.5f,5f)] private float _flightSpeed;
    [SerializeField, Range(0.1f, 0.5f)] private float _durationDistanceCheckTimer;
    [SerializeField] private TimerMode _timerMode;
    [SerializeField] private AnimationCurve _speedCurve;

    public float Distance => _distance;
    public float FlightSpeed => _flightSpeed;
    public float DurationDistanceCheckTimer => _durationDistanceCheckTimer;
    public TimerMode TimerMode => _timerMode;
    public AnimationCurve SpeedCurve => _speedCurve;
}
