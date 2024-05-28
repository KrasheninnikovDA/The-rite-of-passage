using System.Collections.Generic;
using UnityEngine;

public class PlatformCreater : MonoBehaviour
{
    [SerializeField] private GameObject _prefRaft;
    [SerializeField] private Transform _pointCreate;
    private Timer _createRaftTimer;
    private Queue<GameObject> _swithDirectionActions;

    private void Start() 
    {
        _swithDirectionActions = new();
        _createRaftTimer = new(4f,TimerMode.loop);
        _createRaftTimer.ActionStartTimer.Subscribe(CreateRaft);
        _createRaftTimer.Start();   
    }

    private void Update()
    {
        _createRaftTimer.Update();
    }

    private void CreateRaft()
    {
        Vector2 coordinatCrateRaft = _pointCreate.TransformDirection(_pointCreate.position);
        GameObject platform = GameObject.Instantiate(_prefRaft, coordinatCrateRaft, Quaternion.identity);
        
        AddActionDestroyRaft(platform);
    }

    private void AddActionDestroyRaft(GameObject platform)
    {
        MovingPlatform raft = platform.GetComponentInChildren<MovingPlatform>();
        if(raft != null)
        {
            raft.SwithDirectionAction.Subscribe(Dequeue);
            _swithDirectionActions.Enqueue(platform);
        }
    }

    private void Dequeue()
    {
        Destroy(_swithDirectionActions.Dequeue());
    }
}
