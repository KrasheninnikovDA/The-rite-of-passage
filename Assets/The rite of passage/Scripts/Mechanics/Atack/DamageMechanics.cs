
using UnityEngine;

public class DamageMechanics<T> where T : IDamaged
{
    private AtomickAction _hittingTarget;

    public DamageMechanics()
    {}
    public DamageMechanics( AtomickAction hittingTarget)
    {
        _hittingTarget = hittingTarget;
    }

    public void Hit(Collision2D collision)
    { 
        IDamaged target = collision.gameObject.GetComponent<T>();
        if (target != null) 
        {
            target.TakeDamage();
            _hittingTarget?.Invoke();
        }
    }
}
