using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private GameObject _prefBoomerang;
    [SerializeField] private Transform _leftPointOfShotTransform;
    [SerializeField] private Transform _rightPointOfShotTransform;
    [SerializeField] private SpriteRenderer _shooterSpriteRenderer;
    [SerializeField] private int _maxShall;
    [SerializeField] private float _firingFrequency;
    [SerializeField] private float _rechargeSeconds;

    private int _currentShall;
    private AbsInput _inputSystem;
    private RangeAtackMechanics _rangeAtackMechanics;
    private Timer _rechargeTimer;
    private Timer _firingFrequencyTimer;
    private AtomickAction _endLifeCycleShell;
    private bool _isAllive = true;

    public void Construct(AbsInput inputSystem)
    {
        _inputSystem = inputSystem;
        _currentShall = _maxShall;
        _rangeAtackMechanics = new(_prefBoomerang, _leftPointOfShotTransform, _rightPointOfShotTransform, _shooterSpriteRenderer);
        _rechargeTimer = new Timer(_rechargeSeconds, TimerMode.singlnes);
        _firingFrequencyTimer = new(_firingFrequency, TimerMode.singlnes);
        _rechargeTimer.ActionStopTimer.Subscribe(Recharge);
    }

    private void Update()
    {
        Shoot(_inputSystem.Atack);
        _firingFrequencyTimer.Update();
        _rechargeTimer.Update();
        EventBus.UpdateDrowTimerRecovery?.Invoke(_rechargeTimer.PercentageOfCompletion);
    }

    public void OnDisable()
    {
        _rechargeTimer.ActionStopTimer.Unsubscribe(Recharge);
        _endLifeCycleShell?.Unsubscribe(ChackShell);
        _isAllive = false;
    }

    private void Shoot(bool inputSignal)
    {
        if (inputSignal && _currentShall > 0 && _isAllive && !_firingFrequencyTimer.Runing)
        {
            _rangeAtackMechanics.Shoot();
            _endLifeCycleShell = _rangeAtackMechanics.EndLifeCycleShell;
            _endLifeCycleShell?.Subscribe(ChackShell);
            _firingFrequencyTimer.Start();
            _currentShall--;
            EventBus.Invoke(AllNameEvent.AtackPlayer);
        }
    }

    private void ChackShell()
    {
        if (_currentShall <= 0)
        {
            _rechargeTimer.Start();
            _endLifeCycleShell?.Unsubscribe(ChackShell);
        }
    }

    public void AddShall()
    {
        if (_currentShall <= _maxShall)
        {
            _currentShall++;
        } 
    }

    private void Recharge()
    {
        _currentShall = _maxShall;
        EventBus.Invoke(AllNameEvent.Recharge);
    }
}
