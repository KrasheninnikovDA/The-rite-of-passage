using System;

[Serializable]
public sealed class AtomickAction
{
    private event Action _onAction;

    public void Invoke()
    {
        _onAction?.Invoke();
    }

    public void Subscribe(Action action)
    {
        _onAction += action;
    }

    public void Unsubscribe(Action action)
    {
        _onAction -= action;
    }
}
