
using UnityEngine;

public class PlayerInstaller : MonoBehaviour
{
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private PlayerShooter _shooter;
    [SerializeField] private PlayerAnimationSwitcher _playerAnimationSwitcher;
    [SerializeField] private PlayerHP _playerHP;
    [SerializeField] private AbsInput _playerInput;
    [SerializeField] private PlayerDying _playerDying;
    [SerializeField] private SoundController _playerSoundController;

    private SignalHolder _playerSignalHolder;

    private void Awake()
    {
        _playerSignalHolder = new();
        _playerAnimationSwitcher.Construct(_playerSignalHolder);
        _shooter.Construct(_playerInput);
        _playerMover.Construct(_playerInput, _playerSignalHolder);
        _playerHP.Construct(_playerSignalHolder);
        _playerDying.Construct(_playerSignalHolder);
        _playerSoundController.Construct(_playerSignalHolder);
    }
}
