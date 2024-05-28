
public class EnemyHP : AbsHPHolder
{
    private HPControlMechanics _hpControlMechanics;
    private SignalHolder _signalHolder;

    public override void Construct(SignalHolder signalHolder)
    {
        _signalHolder = signalHolder;
        base._currentHP = new(base.maxHP);
        _hpControlMechanics = new(base._currentHP, base.safePeriodSecods);
        _hpControlMechanics.TakeDamageAction.Subscribe(SendSignalAboutDamage);
        _hpControlMechanics.DeathAction.Subscribe(SendSignalAboutDeath);
    }

    public override void TakeDamage()
    {
        _hpControlMechanics.TakeDamage();
        _signalHolder.SignalForSoundController.Invoke(AllNameSignal.Damage);
    }

    private void SendSignalAboutDamage()
    {

        _signalHolder.SignalForSoundController.Invoke(AllNameSignal.Damage);
        _signalHolder.Damage.Invoke();
    }

    private void SendSignalAboutDeath()
    {
        _signalHolder.SignalForAnimator.Invoke(AllNameSignal.Death);
        _signalHolder.SignalForSoundController.Invoke(AllNameSignal.Death);
        _signalHolder.DeathSignal.Invoke();
        _hpControlMechanics.TakeDamageAction.Unsubscribe(SendSignalAboutDamage);
        _hpControlMechanics.DeathAction.Unsubscribe(SendSignalAboutDeath);
        EventBus.Invoke(AllNameEvent.AddPoint);
    }

    private void Update()
    {
        _hpControlMechanics.UpdateSafePeriodTimer();
    }
}
