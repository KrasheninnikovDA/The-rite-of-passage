
using System.Collections.Generic;

public class AngryPigAnimatorSwitch : AbsAnimatorSwitcher
{
    public override void Construct(SignalHolder signalHolder)
    {
        base.Construct(signalHolder);
        base._animations = new Dictionary<AllNameSignal, string>()
        {
            { AllNameSignal.Idle, "Pig Idle"},
            {AllNameSignal.Move, "Pig Walk"},
            {AllNameSignal.RageMove, "Pig Run"},
            { AllNameSignal.Damage, "Pig Hit"},
            { AllNameSignal.Death, "Pig Hit"}
        };

        PlayStartAnimation(AllNameSignal.Idle);
    }

    private void PlayStartAnimation(AllNameSignal startAnimation)
    {
        base.Switch(startAnimation);
    }
}
