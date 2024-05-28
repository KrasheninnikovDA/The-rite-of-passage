
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveStrategy : AbsStrategy
{
    [SerializeField] private Variable<float> moveSpeed;
    [SerializeField] private Transform _positionTargetPoint1;
    [SerializeField] private Transform _positionTargetPoint2;
    [SerializeField] private SpriteRenderer spriteMover;

    private Variable<bool> isGrounded = new(true);
    private Variable<bool> isMoving = new(true);
    private MoveMechanics _moveMechanics;
    private DeterminDirectionMechanics _determinDirectionMechanics;

    public override void Constuct(SignalHolder signalHolder)
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        _determinDirectionMechanics = new(transform, _positionTargetPoint1.position, _positionTargetPoint2.position);
        _moveMechanics = new(rb, moveSpeed, isGrounded, isMoving, signalHolder,AllNameSignal.Move);
    }

    public override void ControlledUpdate()
    {
        float direction =_determinDirectionMechanics.GetCurrentDirection();
        SetFllipX(direction);
        _moveMechanics.Update(direction);
    }

    private void SetFllipX(float direction)
    {
        spriteMover.flipX = direction > 0;
    }
}
