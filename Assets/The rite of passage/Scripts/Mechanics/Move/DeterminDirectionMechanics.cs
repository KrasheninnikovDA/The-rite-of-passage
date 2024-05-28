using UnityEngine;

public class DeterminDirectionMechanics
{
    private Transform _transformMover;
    private Vector3 _positionTargetPointLeft;
    private Vector3 _positionTargetPointRight;
    private Vector3 _currentTarget;
    private Timer _distanceCheckTimer;
    private DirectionMovment _currentDerection;

    public DeterminDirectionMechanics(Transform transformMover, Vector3 positionTargetPoint1, Vector3 positopnTargetPoint2)
    {
        _transformMover = transformMover;
        _positionTargetPointLeft = positionTargetPoint1;
        _positionTargetPointRight = positopnTargetPoint2;
        _currentTarget = positionTargetPoint1;
        _distanceCheckTimer = new(0.3f, TimerMode.singlnes);
        _currentDerection = DirectionMovment.right;
    }

    public float GetCurrentDirection()
    {
        CheckEndPath();
        return (float)_currentDerection;
    }

    public bool CheckLocationWithinPatrolArea()
    {
        Vector2 currentPositionMover = _transformMover.position;
        float distans1 = Vector2.Distance(_positionTargetPointLeft, currentPositionMover);
        float distans2 = Vector2.Distance(_positionTargetPointRight, currentPositionMover);
        _currentTarget = distans1 > distans2 ? _positionTargetPointRight : _positionTargetPointLeft;
        return Mathf.Abs(_transformMover.position.x - _currentTarget.x) <= 0.1f;
    }

    private void CheckEndPath()
    {
        bool endPathX = Mathf.Abs(_transformMover.position.x - _currentTarget.x) <= 0.1f;
        if (endPathX && !_distanceCheckTimer.Runing)
        {
            SwithDirection();
        }
        _distanceCheckTimer.Update();
    }

    private void SwithDirection()
    {
        _currentTarget = SwitchCurrentTarget();
        _distanceCheckTimer.Start();
    }

    private Vector3 SwitchCurrentTarget()
    {
        if (_currentTarget == _positionTargetPointLeft)
        { 
            _currentDerection = DirectionMovment.left;
            return _positionTargetPointRight; 
        }
        _currentDerection = DirectionMovment.right;
        return _positionTargetPointLeft;
    }
}
