using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public AtomickAction SwithDirectionAction => _swithDirectionAction;

    [SerializeField] private float _speedMoving;
    [SerializeField] private Transform _targetPoint1;
    [SerializeField] private Transform _targetPoint2;
    
    private PlatformMoveMechanics _moveMechanics;
    private AtomickAction _swithDirectionAction = new();

    private void Start()
    {
        _moveMechanics = new(transform, _speedMoving, _targetPoint1.position, _targetPoint2.position, _swithDirectionAction);
    }

    void Update()
    {
        _moveMechanics.Update();
    }
}
