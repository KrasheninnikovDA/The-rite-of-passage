using System;

[Serializable]
public sealed class AtomickEvent<T>
{
    private event Action<T> _onEvent;

    public void Invoke(T args)
    {
        _onEvent?.Invoke(args);
    }

    public void Subscribe(Action<T> action)
    {
        _onEvent += action;
    }

    public void Unsubscribe(Action<T> action)
    {
        _onEvent -= action;
    }
}
