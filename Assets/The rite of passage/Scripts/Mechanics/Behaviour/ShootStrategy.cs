using UnityEngine;

public class ShootStrategy : AbsStrategy
{
    [SerializeField] private GameObject _prefShell;
    [SerializeField] private Transform _leftPointOfShotTransform;
    [SerializeField] private Transform _rightPointOfShotTransform;
    [SerializeField] private SpriteRenderer _spriteRendererShooter;
    [SerializeField] private float _firingFrequency;

    private SignalHolder _signalHolder;
    private RangeAtackMechanics _rangeAtackMechanics;
    private Timer _firingFrequencyTimer;

    public override void Constuct(SignalHolder signalHolder)
    {
        _signalHolder = signalHolder;
        _rangeAtackMechanics = new(_prefShell, _leftPointOfShotTransform, _rightPointOfShotTransform, _spriteRendererShooter);
        _firingFrequencyTimer = new(_firingFrequency,TimerMode.loop);
        _firingFrequencyTimer.ActionStopTimer.Subscribe(Shoot);
        _firingFrequencyTimer.Start();
    }

    public override void ControlledUpdate()
    {
        _signalHolder.SignalForAnimator.Invoke(AllNameSignal.Atack);
        _firingFrequencyTimer.Update();
    }

    public void Shoot()
    {
        _rangeAtackMechanics.Shoot();
    }
}
