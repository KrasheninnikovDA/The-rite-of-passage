
using System.Collections.Generic;

public class ArrowPlantAnimatorSwitcher : AbsAnimatorSwitcher
{
    public override void Construct(SignalHolder signalHolder)
    {
        base.Construct(signalHolder);
        base._animations = new Dictionary<AllNameSignal, string>()
        {
            { AllNameSignal.Idle, "PlantIdle" },
            {AllNameSignal.Atack, "PlantAtack"},
            { AllNameSignal.Damage, "PlantHit"},
            { AllNameSignal.Death, "PlantHit"}
        };

        PlayStartAnimation(AllNameSignal.Idle);
    }

    private void PlayStartAnimation(AllNameSignal startAnimation)
    {
        base.Switch(startAnimation);
    }
}
