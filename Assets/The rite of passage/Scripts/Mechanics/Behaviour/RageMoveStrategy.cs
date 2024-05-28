
using UnityEngine;

public class RageMoveStrategy : AbsStrategy
{
    [SerializeField] private Variable<float> _moveSpeed;
    [SerializeField] private Transform _positionTargetPointRight;
    [SerializeField] private Transform _positionTargetPointLeft;
    [SerializeField] private Transform _positionStartingLeftRay;
    [SerializeField] private Transform _positionStartingRightRay;
    [SerializeField] private float _distanseDetectedPlayer;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private SpriteRenderer _spriteMover;

    private Variable<bool> _isGrounded = new(true);
    private Variable<bool> _isMoving = new(true);
    private MoveMechanics _moveMechanics;
    private DeterminDirectionMechanics _determinDirectionMechanics;
    private const float _leftDirection = -1;
    private const float _rightDirection = 1;

    public override void Constuct(SignalHolder signalHolder)
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        _moveMechanics = new(rb, _moveSpeed, _isGrounded, _isMoving, signalHolder, AllNameSignal.RageMove);
        _determinDirectionMechanics = new(transform, _positionTargetPointLeft.position, _positionTargetPointRight.position);
    }

    public override void ControlledUpdate()
    {
        float direction = GetDirection();
        if (!_determinDirectionMechanics.CheckLocationWithinPatrolArea())
        {
            _moveMechanics.Update(direction);
        }
        SetFllipX(direction);
    }

    private void SetFllipX(float direction)
    {
        _spriteMover.flipX = direction > 0;
    }

    private float GetDirection()
    {
        if (CheckPlayerDetection(_positionStartingLeftRay.position, Vector2.left))
        {
            return _leftDirection;
        }
        if (CheckPlayerDetection(_positionStartingRightRay.position, Vector2.right))
        {
            return _rightDirection;
        }
        return GetCirrentDirection();
    }

    private bool CheckPlayerDetection(Vector2 positionStartingRay, Vector2 direction)
    {
        RaycastHit2D raycastHit2D = Physics2D.Raycast(positionStartingRay, direction, _distanseDetectedPlayer, _layerMask);
        PlayerHP playerHP = raycastHit2D.collider?.GetComponent<PlayerHP>();
        return playerHP != null;
    }

    private float GetCirrentDirection()
    {
        if (_spriteMover.flipX)
        {
            return _rightDirection;
        }
        return _leftDirection;   

    }
}
