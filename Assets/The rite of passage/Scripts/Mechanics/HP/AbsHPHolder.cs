
using UnityEngine;

public abstract class AbsHPHolder : MonoBehaviour, IDamaged
{
    [SerializeField] protected int maxHP;
    [SerializeField] protected float safePeriodSecods;
    
    protected Variable<int> _currentHP;

    public abstract void Construct(SignalHolder signalHolder);

    public abstract void TakeDamage();
}
