
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour, IFired
{
    public AtomickAction EndLifeCycle { private set; get; }

    [SerializeField] private float _speedBoolet;
    private DamageMechanics<PlayerHP> _damageMechanics;
    private BulletMoveMechanics _bulletMoveMechanics;

    public void ConstructShells(DirectionMovment startDirectionShot)
    {
        EndLifeCycle = new();
        EndLifeCycle.Subscribe(DestroyBullet);
        _damageMechanics = new(EndLifeCycle);
        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
        _bulletMoveMechanics = new(rigidbody2D, startDirectionShot, _speedBoolet);
    }

    private void Update()
    {
        _bulletMoveMechanics.Update();
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        _damageMechanics.Hit(other);
        EndLifeCycle.Invoke();
    }

    private void DestroyBullet()
    {
        EndLifeCycle.Unsubscribe(DestroyBullet);
        Destroy(gameObject);        
    }
}
