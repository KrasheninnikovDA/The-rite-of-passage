using UnityEngine;

public class DeathStrategy : AbsStrategy
{
    [SerializeField] private float _daethseconds;
    private Timer _daethTimer;
    private SignalHolder _signalHolder;

    public override void Constuct(SignalHolder signalHolder)
    {
        _signalHolder = signalHolder;
        _daethTimer = new(_daethseconds, TimerMode.singlnes);
        _daethTimer.ActionStopTimer.Subscribe(Death);
        _daethTimer.Start();
    }

    public override void ControlledUpdate()
    {
        _signalHolder.SignalForAnimator.Invoke(AllNameSignal.Death);
        _daethTimer.Update();
    }

    private void Death()
    {
        if(transform.parent != null)
        {
            GameObject parent = transform.parent.gameObject;
            Destroy(parent);
            return;
        }    
        Destroy(gameObject);
    }
}
