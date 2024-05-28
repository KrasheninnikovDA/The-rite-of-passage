using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private LayerMask _layerForJump;
    [SerializeField] private Variable<float> _speedMove;
    [SerializeField] private Variable<float> _maxJumpForce;
    [SerializeField] private SpriteRenderer _moverSpriteRenderer;

    private Variable<bool> _isGrounded = new(true);
    private Variable<bool> _isMoving = new(false);
    private AtomickEvent<AllNameSignal> _signalForAnimator;
    private bool _isAlive = true;

    private AbsInput _inputSystem;
    private SurfaceDeterminant _surfaceDeterminant;
    private MoveMechanics _moveMechanics;
    private JumpMechanics _jumpMechanics;
    private PlatformMechanics _platformMechanics;

    public void Construct(AbsInput inputSystem, SignalHolder playerSignalHolder)
    {
        _signalForAnimator = playerSignalHolder.SignalForAnimator;
        _inputSystem = inputSystem;
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        _surfaceDeterminant = new(rigidbody, _isGrounded, _layerForJump);
        _jumpMechanics = new(rigidbody, _maxJumpForce, _isGrounded, playerSignalHolder);
        _moveMechanics = new(rigidbody, _speedMove, _isGrounded, _isMoving, playerSignalHolder, AllNameSignal.Move);
        _platformMechanics = new(rigidbody);
    }

    private void Update()
    {
        _surfaceDeterminant.ChackGround();
        _moveMechanics.Update(_inputSystem.HorizontalMove);
        _jumpMechanics.Update(_inputSystem.JumpIsUp, _inputSystem.JumpIsDown);
        DeterminFlipX();
        ChackIdleStatus();
    }

    private void DeterminFlipX()
    {
        if (_isAlive)
        {
            _moverSpriteRenderer.flipX = _inputSystem.FlipX;
        }
    }

    private void ChackIdleStatus()
    {
        if (_isGrounded.Value && !_isMoving.Value && _isAlive)
        {
            _signalForAnimator?.Invoke(AllNameSignal.Idle);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ReactToSurface(collision);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        _platformMechanics.FallThroughPlatform(collision, _inputSystem.FallThroughPlatform);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        ReactToSurface(null);
    }

    private void ReactToSurface(Collision2D collision)
    {
        _platformMechanics.ReactToMovingPlatform(collision);
    }

    public void OnDisable()
    {
        _isAlive = false;
        _moveMechanics.ReactionToDeath();
        _jumpMechanics.ReactionToDeath();
        _platformMechanics.ReactionToDeath();
    }
}
