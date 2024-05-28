using UnityEngine;

public class PlatformMoveMechanics 
{
    private Transform _transformPlatform;
    private float _movementSpeed;
    private Vector3 _positionTargetpoint1;
    private Vector3 _positionTargetpoint2;
    private Vector3 _currentTarget;
    private Timer _distanceCheckTimer;
    private readonly AtomickAction _swithDirectionAction;

    public PlatformMoveMechanics(Transform transformPlatform, float movementSpeed, Vector3 positionTargetPoint1, Vector3 positopnTargetPoint2, AtomickAction swithDirectionAction)
    {
        _transformPlatform = transformPlatform;
        _movementSpeed = movementSpeed;
        _positionTargetpoint1 = positionTargetPoint1;
        _positionTargetpoint2 = positopnTargetPoint2;
        _currentTarget = positionTargetPoint1;
        _distanceCheckTimer = new(0.3f, TimerMode.singlnes);
        _swithDirectionAction = swithDirectionAction;
    }

    public void Update()
    {
        _transformPlatform.position = Vector3.MoveTowards(_transformPlatform.position, _currentTarget, _movementSpeed * Time.deltaTime);
        CheckEndPath();
    }

    private void CheckEndPath()
    {
        bool endPathX = Mathf.Abs(_transformPlatform.position.x - _currentTarget.x) <= 0.01f;
        bool endPathY = Mathf.Abs(_transformPlatform.position.y - _currentTarget.y) <= 0.01f;
        if (endPathX && endPathY && !_distanceCheckTimer.Runing)
        {
            SwithDirection();
        }
        _distanceCheckTimer.Update();
    }

    private void SwithDirection()
    {
        _swithDirectionAction.Invoke();
        _currentTarget = SwitchCurrentTarget();
        _distanceCheckTimer.Start();
    }

    private Vector3 SwitchCurrentTarget()
    {
        if (_currentTarget == _positionTargetpoint1)
        { 
            return _positionTargetpoint2; 
        }
        return _positionTargetpoint1;
    }
}
