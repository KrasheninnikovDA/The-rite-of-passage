
using System.Collections.Generic;
using UnityEngine;

public class AngryPigBehaviour : MonoBehaviour
{
    public AtomickAction DamageAction {set; private get;}
    [SerializeField] private StrategySwitcher _strategySwitcher;
    [SerializeField] private float _idleSeconds;
    [SerializeField] private float _moveSeconds;
    [SerializeField] private float _rageSeconds;
    [SerializeField] private float _damageSeconds;

    private Timer _idleTimer;
    private Timer _moveTimer;
    private Timer _rageTimer;
    private Timer _damageTimer;
    private Timer _curerntTimer;
    private Queue<Timer> _regularQueue;
    private bool isAlive = true;

    public void Construct(SignalHolder signalHolder)
    {
        ConstructIdleTimer();
        ConstructMoveTimer();
        ConstructDamageTimer();
        ConstructRageTimer();
        ConstructRegularQueue();
        signalHolder.Damage.Subscribe(StartDamageTimer);
        signalHolder.DeathSignal.Subscribe(OnDeathStrategy);
        _curerntTimer.Start();
    }

    private void ConstructIdleTimer()
    {
        _idleTimer = new(_idleSeconds,TimerMode.singlnes);
        _idleTimer.ActionStartTimer.Subscribe(OnIdleStrategy);
        _idleTimer.ActionStopTimer.Subscribe(StartTimerRegularQueue);
        _curerntTimer = _idleTimer;
    }

    private void ConstructMoveTimer()
    {
        _moveTimer = new(_moveSeconds, TimerMode.singlnes);
        _moveTimer.ActionStartTimer.Subscribe(OnMoveStrategy);
        _moveTimer.ActionStopTimer.Subscribe(StartTimerRegularQueue);
    }

    private void ConstructDamageTimer()
    {
        _damageTimer = new(_damageSeconds,TimerMode.singlnes);
        _damageTimer.ActionStartTimer.Subscribe(OnDamageStrategy);
        _damageTimer.ActionStopTimer.Subscribe(StartTimerRegularQueue);
    }

    private void ConstructRageTimer()
    {
        _rageTimer = new(_rageSeconds,TimerMode.singlnes);
        _rageTimer.ActionStartTimer.Subscribe(OnRageStrategy);
        _rageTimer.ActionStopTimer.Subscribe(StartTimerRegularQueue);
    }

    private void ConstructRegularQueue()
    {
        Timer[] timers ={_moveTimer, _idleTimer};
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

    private void OnMoveStrategy()
    {
        _strategySwitcher.Switch(typeof(MoveStrategy));
    }

    private void OnDamageStrategy()
    {
        _strategySwitcher.Switch(typeof(TakingDamageStrategy));
    }

    private void OnRageStrategy()
    {
        _strategySwitcher.Switch(typeof(RageMoveStrategy));
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

    private void OnTriggerEnter2D(Collider2D other) 
    {
        PlayerHP playerHP = other.GetComponent<PlayerHP>();
        if (playerHP != null)
        {
            _curerntTimer = _rageTimer;
            _curerntTimer.Start();
        }
    }
}
