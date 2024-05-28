
using System.Collections.Generic;
using UnityEngine;

public class ArrowPlantBehaviour : MonoBehaviour
{
    public AtomickAction DamageAction {set; private get;}

    [SerializeField] private StrategySwitcher _strategySwitcher;
    [SerializeField] private float _idleSeconds;
    [SerializeField] private float _shootSeconds;
    [SerializeField] private float _damageSeconds;

    private Timer _idleTimer;
    private Timer _shootTimer;
    private Timer _damageTimer;
    private Timer _curerntTimer;
    private Queue<Timer> _regularQueue;
    private bool isAlive = true;

    public void Construct(SignalHolder signalHolder)
    {
        ConstructIdleTimerShort();
        ConstructDamageTimer();
        ConstructShootTimer();
        ConstructRegularQueue();

        signalHolder.Damage.Subscribe(StartDamageTimer);
        signalHolder.DeathSignal.Subscribe(OnDeathStrategy);
        
        _curerntTimer.Start();
    }

    private void ConstructIdleTimerShort()
    {
        _idleTimer = new(_idleSeconds,TimerMode.singlnes);
        _idleTimer.ActionStartTimer.Subscribe(OnIdleStrategy);
        _idleTimer.ActionStopTimer.Subscribe(StartTimerRegularQueue);
        _curerntTimer = _idleTimer;
    }

    private void ConstructShootTimer()
    {
        _shootTimer = new(_shootSeconds,TimerMode.singlnes);
        _shootTimer.ActionStartTimer.Subscribe(OnShootStrategy);
        _shootTimer.ActionStopTimer.Subscribe(StartTimerRegularQueue);
    }

    private void ConstructDamageTimer()
    {
        _damageTimer = new(_damageSeconds,TimerMode.singlnes);
        _damageTimer.ActionStartTimer.Subscribe(OnDamageStrategy);
        _damageTimer.ActionStopTimer.Subscribe(StartTimerRegularQueue);
    }

    private void ConstructRegularQueue()
    {
        Timer[] timers ={_shootTimer, _idleTimer};
        _regularQueue = new(timers);
    }

    private void StartTimerRegularQueue()
    {
        Timer timer = _regularQueue.Dequeue();
        _curerntTimer = timer;
        _curerntTimer.Start();
        _regularQueue.Enqueue(timer);
    }

    private void StartDamageTimer()
    {
        _curerntTimer = _damageTimer;
        _curerntTimer.Start();
    }

    private void OnIdleStrategy()
    {
        _strategySwitcher.Switch(typeof(IdleStategy));
    }

    private void OnShootStrategy()
    {
        _strategySwitcher.Switch(typeof(ShootStrategy));
    }

    private void OnDamageStrategy()
    {
        _strategySwitcher.Switch(typeof(TakingDamageStrategy));
    }

    private void OnDeathStrategy()
    {
        isAlive = false;
        _strategySwitcher.Switch(typeof(DeathStrategy));
    }

    private void Update() 
    {
        if(isAlive)
        {
            _curerntTimer?.Update();
        }
    }
}
