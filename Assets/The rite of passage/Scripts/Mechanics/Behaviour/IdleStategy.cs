
public class IdleStategy : AbsStrategy
{
    private SignalHolder _signalHolder;

    public override void Constuct(SignalHolder signalHolder)
    {
        _signalHolder = signalHolder;
    }

    public override void ControlledUpdate()
    {
        _signalHolder.SignalForAnimator.Invoke(AllNameSignal.Idle);
    }
}
