using System.Collections;
using UnityEngine;

public class PlayerHP : AbsHPHolder
{
    [SerializeField] private float _secondPlayDeatAnimation;

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
    }

    private void Update()
    {
        _hpControlMechanics.UpdateSafePeriodTimer();
    }

    private void SendSignalAboutDamage()
    {
        _signalHolder.SignalForSoundController.Invoke(AllNameSignal.Damage);
        _signalHolder.SignalForAnimator.Invoke(AllNameSignal.Damage);
        _signalHolder.Damage.Invoke();
        EventBus.Invoke(AllNameEvent.DamagePlayer);
    }

    private void SendSignalAboutDeath()
    {
        EventBus.Invoke(AllNameEvent.DamagePlayer);
        _signalHolder.SignalForAnimator.Invoke(AllNameSignal.Death);
        _signalHolder.SignalForSoundController.Invoke(AllNameSignal.Death);
        _signalHolder.DeathSignal.Invoke();
        _hpControlMechanics.TakeDamageAction.Unsubscribe(SendSignalAboutDamage);
        _hpControlMechanics.DeathAction.Unsubscribe(SendSignalAboutDeath);
        StartCoroutine(InvokeDeathPlayer());
    }

    private IEnumerator InvokeDeathPlayer()
    {
        yield return new WaitForSeconds(_secondPlayDeatAnimation);
        EventBus.Invoke(AllNameEvent.DeathPayer);
    }
}
