using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Boomerang : MonoBehaviour, IFired
{
    [SerializeField] private BoomerangConfig _config;

    public AtomickAction CollisionAction => _collisionAction;
    public AtomickAction EndLifeCycle => _endLifeCycle;

    private AtomickAction _collisionAction = new();
    private AtomickAction _endLifeCycle = new();
    private BoomerangMoveMechanics _boomerangMoveMechanics;
    private DamageMechanics<EnemyHP> _damageMechanics;
    private BoomerangCatchMechanics _catchMechanics;

    public void ConstructShells(DirectionMovment startDirectionShot)
    {
        Rigidbody2D boody = GetComponent<Rigidbody2D>();
        EndLifeCycle.Subscribe(DestroyBoomerang);
        _boomerangMoveMechanics = new(boody, startDirectionShot, _config, CollisionAction, _endLifeCycle);
        _damageMechanics = new(CollisionAction);
        _catchMechanics = new(CollisionAction, _endLifeCycle);
    }

    void Update()
    {
        _boomerangMoveMechanics.Update();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _damageMechanics.Hit(collision);
        _catchMechanics.HandleCollision(collision);
    }

    private void DestroyBoomerang()
    {
        EndLifeCycle.Unsubscribe(DestroyBoomerang);
        Destroy(this.gameObject);

    }
}
