using UnityEngine;

public class JumpMechanics
{
    private readonly Variable<float> _maxJumpForce;
    private readonly SignalHolder _signalHolder;
    private Variable<bool> _isGrounded;
    private Rigidbody2D _body;
    private bool _processOfJumping;
    private int _counterJump;
    private Timer _timerJump;
    private bool _isAlive = true;

    public JumpMechanics(Rigidbody2D body, Variable<float> maxJumpForce, Variable<bool> isGrounded, SignalHolder signalHolder)
    {
        _body = body;
        _maxJumpForce = maxJumpForce;
        _timerJump = new(0.3f, TimerMode.singlnes);
        _counterJump = 1;
        _signalHolder = signalHolder;
        _isGrounded = isGrounded;
    }

    public void Update(bool jumpIsUp, bool jumpIsDown)
    {
        ChackGrounded();
        Jump(jumpIsUp, jumpIsDown);
    }

    public void ReactionToDeath()
    {
        _body.velocity = new Vector2(_body.velocity.x, 0);
        _isAlive = false;
    }

    private void ChackGrounded()
    {
        if (_isGrounded.Value)
        {
            _timerJump.Start();
            _counterJump += 1;
        }
    }

    private void Jump(bool jumpIsUp, bool jumpIsDown)
    {
        JumpUp(jumpIsUp);
        JumpDown(jumpIsDown);
        _timerJump.Update();
        CheckProcessOfJump();
    }

    private void JumpUp(bool jumpIsUp)
    {
        bool abilityToJump = (_isGrounded.Value || _timerJump.Runing) && _counterJump > 0 && _isAlive;
        if (jumpIsUp && abilityToJump)
        {
            _signalHolder.SignalForSoundController?.Invoke(AllNameSignal.Jump);
            _body.velocity = new Vector2(_body.velocity.x, _maxJumpForce.Value);
            _processOfJumping = true;
            _counterJump -= 1;
        }
    }

    private void JumpDown(bool jumpIsDown)
    {
        if (jumpIsDown && _processOfJumping && !_isGrounded.Value)
        {
            _body.velocity = new Vector2(_body.velocity.x, _body.velocity.y / 2);
            _processOfJumping = false;
        }
    }

    private void CheckProcessOfJump()
    {
        if (!_isGrounded.Value)
        {
            _signalHolder.SignalForAnimator?.Invoke(AllNameSignal.Jump);
        }
    }
}
