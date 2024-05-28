
using UnityEngine;

public enum TimerMode
{
    loop,
    singlnes
}

public class Timer
{
    public AtomickAction ActionStartTimer = new();
    public AtomickAction ActionStopTimer = new();
    public bool Runing { private set; get; }
    public float PercentageOfCompletion => _currentTime / _duration;

    private float _duration;
    private float _currentTime;
    private TimerMode _mode;

    public Timer(float duration, TimerMode mode)
    {
        _duration = duration;
        _mode = mode;
        _currentTime = 0;
        Runing = false;
    }

    public void Start()
    {
        ActionStartTimer?.Invoke();
        Runing = true;
    }

    public void Update()
    {
        if (Runing)
        {
            _currentTime += Time.deltaTime;
            CheckEndTimer();
        }
    }

    public void Stop() 
    {
        ActionStopTimer?.Invoke();
        Runing = false;
        _currentTime = 0;
        CheckLoop();
    }

    private void CheckEndTimer()
    {
        if (_currentTime >= _duration)
        {
            Stop();
        }
    }

    private void CheckLoop()
    {
        if (_mode == TimerMode.loop)
        {
            Start();
        }
    }
}
