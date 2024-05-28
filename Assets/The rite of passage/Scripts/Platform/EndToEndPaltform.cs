using UnityEngine;

[RequireComponent(typeof(PlatformEffector2D))]
public class EndToEndPaltform : MonoBehaviour
{
    [SerializeField] private float _timeRefresh;
    private PlatformEffector2D _platform;
    private Timer _timer;
    private float _startSurfaceArc;

    private void Start()
    {
        _platform = GetComponent<PlatformEffector2D>();
        _startSurfaceArc = _platform.surfaceArc;
        _timer = new(_timeRefresh, TimerMode.singlnes);
        _timer.ActionStartTimer.Subscribe(SetSurfaceArcZiro);
        _timer.ActionStopTimer.Subscribe(RefrashSurfaceArc);
    }

    public void OnEnablePlatform()
    {
        _timer.Start();
    }

    private void SetSurfaceArcZiro()
    {
        _platform.surfaceArc = 0;
    }

    private void RefrashSurfaceArc()
    {
        _platform.surfaceArc = _startSurfaceArc;
    }

    void Update()
    {
        _timer.Update();
    }

    private void OnDestroy()
    {
        _timer.ActionStartTimer.Unsubscribe(SetSurfaceArcZiro);
        _timer.ActionStopTimer.Unsubscribe(RefrashSurfaceArc);
    }
}
