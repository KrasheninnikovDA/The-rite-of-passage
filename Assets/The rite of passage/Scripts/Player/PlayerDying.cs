
using UnityEngine;

public class PlayerDying : MonoBehaviour
{
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private PlayerShooter _shooter;
    private SignalHolder _playerSignalHolder;

    public void Construct(SignalHolder playerSignalHolder)
    {
        _playerSignalHolder = playerSignalHolder;
        _playerSignalHolder.DeathSignal.Subscribe(DeathPalyer);
    }

    private void DeathPalyer()
    {
        _playerMover.OnDisable();
        _shooter.OnDisable();
    }

    private void OnDestroy()
    {
        _playerSignalHolder.DeathSignal.Unsubscribe(DeathPalyer);
    }
}
