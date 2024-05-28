using System.Collections.Generic;

public class PlayerAnimationSwitcher : AbsAnimatorSwitcher
{
    public override void Construct(SignalHolder signalHolder)
    {
        base.Construct(signalHolder);
        base._animations = new Dictionary<AllNameSignal, string>()
        {
            { AllNameSignal.Idle, "Mask Dude Idle" },
            { AllNameSignal.Move, "Mask Dude Run"},
            { AllNameSignal.Jump, "Mask Dude Jump"},
            { AllNameSignal.Damage, "Mask Dude Hit"},
            { AllNameSignal.Death, "Mask Dude Death"}
        };

        PlayStartAnimation(AllNameSignal.Idle);
    }

    private void PlayStartAnimation(AllNameSignal startAnimation)
    {
        base.Switch(startAnimation);
    }
}
