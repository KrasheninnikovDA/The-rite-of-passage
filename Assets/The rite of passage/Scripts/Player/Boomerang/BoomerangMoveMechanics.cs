using UnityEngine;

public class BoomerangMoveMechanics
{
    private Rigidbody2D _boody;
    private float _distance;
    private float _flightSpeed;
    private int _direction;
    private Vector3 _startPosition;
    private Transform _transformBoomerang;
    private Timer _distanceCheckTimer;
    private AnimationCurve _speedCurve;
    private int _currentNumberOfDirectionChanges;

    private AtomickAction _endLifeCycle;
    private const int _maxNumberOfDirectionChanges = 2;

    public BoomerangMoveMechanics(Rigidbody2D boody, DirectionMovment startDirectionShot, BoomerangConfig config, AtomickAction collisionAction, AtomickAction endLifeCycle)
    {
        DeterminRigidBodyParametr(boody);
        InstallConfig(config);
        ManageAction(collisionAction, endLifeCycle);
        _direction = (int)startDirectionShot;
        _currentNumberOfDirectionChanges = 0;
    }

    private void DeterminRigidBodyParametr(Rigidbody2D boody)
    {
        _boody = boody;
        _transformBoomerang = _boody.transform;
        _startPosition = _transformBoomerang.position;
    }

    private void InstallConfig(BoomerangConfig config)
    {
        _distance = config.Distance;
        _distanceCheckTimer = new(config.DurationDistanceCheckTimer, config.TimerMode);
        _speedCurve = config.SpeedCurve;
        _flightSpeed = config.FlightSpeed;
    }

    private void ManageAction(AtomickAction collisionAction, AtomickAction endLifeCycle)
    {
        _endLifeCycle = endLifeCycle;
        collisionAction.Subscribe(SwithDirection);
    }

    public void Update()
    {
        float currentDistance = Mathf.Abs(_startPosition.x - _transformBoomerang.position.x);
        CheckEndPath(currentDistance);
        float speed = CalculateCurrentSpeed(currentDistance);

        _boody.velocity = new Vector2(speed, 0);
        _distanceCheckTimer.Update();
    }

    private void CheckEndPath(float currentDistance)
    {
        if (currentDistance >= _distance && !_distanceCheckTimer.Runing)
        {
            SwithDirection();
        }
        CheckLifeCycle();
    }

    private void SwithDirection()
    {
        _direction *= -1;
        _distanceCheckTimer.Start();
        _currentNumberOfDirectionChanges += 1;
    }

    private void CheckLifeCycle()
    {
        if (_currentNumberOfDirectionChanges >= _maxNumberOfDirectionChanges)
        {
            _endLifeCycle?.Invoke();
        }
    }

    private float CalculateCurrentSpeed(float currentDistance)
    {
        float relativePath = currentDistance / _distance;
        return _speedCurve.Evaluate(relativePath) * _flightSpeed * _direction;
    }
}
