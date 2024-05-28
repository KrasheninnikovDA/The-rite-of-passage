
using System.Collections.Generic;
using UnityEngine;

public abstract class AbsAnimatorSwitcher: MonoBehaviour
{
    [SerializeField] private Animator _animator;
    protected Dictionary<AllNameSignal, string> _animations;

    public virtual void Construct(SignalHolder signalHolder)
    {
        signalHolder.SignalForAnimator.Subscribe(Switch);
    }

    public virtual void Switch(AllNameSignal state)
    {
        string animationName = _animations[state];
        _animator.Play(animationName);
    }
}
