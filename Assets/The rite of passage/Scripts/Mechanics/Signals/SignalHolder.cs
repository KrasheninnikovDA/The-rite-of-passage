
public enum AllNameSignal
{
    Atack,
    Idle,
    Move,
    RageMove,
    Jump,
    Damage,
    Heal,
    Death,
    PickUpAFruit
}

public class SignalHolder
{
    public AtomickEvent<AllNameSignal> SignalForAnimator { private set; get; }
    public AtomickEvent<AllNameSignal> SignalForSoundController { private set; get; }
    public AtomickAction DeathSignal { private set; get; }
    public AtomickAction Damage { private set; get; }

    public SignalHolder()
    {
        SignalForAnimator = new();
        SignalForSoundController = new();
        DeathSignal = new();
        Damage = new();
    }
}
