using UnityEngine;

public class MoveMechanics
{
    private readonly Variable<float> _moveSpeed;
    private Rigidbody2D _body;
    private readonly SignalHolder _signalHolder;
    private readonly Variable<bool> _isGrounded;
    private Variable<bool> _isMoving;
    private bool _isAlive = true;
    private AllNameSignal _signal;

    public MoveMechanics(Rigidbody2D body, Variable<float> moveSpeed, Variable<bool> isGrounded, Variable<bool> isMoving, SignalHolder signalHolder, AllNameSignal signal)
    {
        _moveSpeed = moveSpeed;
        _body = body;
        _signalHolder = signalHolder;
        _isGrounded = isGrounded;
        _isMoving = isMoving;
        _signal = signal;
        _isMoving.Value = false;
    }

    public void Update(float directionOfMovement)
    {
        Move(directionOfMovement);
    }

    public void ReactionToDeath()
    {
        _body.velocity = new Vector2(0, _body.velocity.y);
        _isAlive = false;
    }

    private void Move(float directionOfMovement)
    {
        if (Mathf.Abs(directionOfMovement) >= 0.01f && _isAlive)
        {
            _body.velocity = new Vector2(_moveSpeed.Value * directionOfMovement, _body.velocity.y);
            _isMoving.Value = true;
            GiveSignal();
        }
        else 
        {
            _body.velocity = new Vector2(0, _body.velocity.y);
            _isMoving.Value = false;
        }
    }

    private void GiveSignal()
    {
        if (_isGrounded.Value)
        {
            _signalHolder.SignalForAnimator?.Invoke(_signal);
        }
    }
}
