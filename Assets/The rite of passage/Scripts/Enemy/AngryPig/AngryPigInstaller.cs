
using UnityEngine;

public class AngryPigInstaller : MonoBehaviour
{
    [SerializeField] private AngryPigAnimatorSwitch _animatorSwitch;
    [SerializeField] private AngryPigBehaviour _angryPigBehaviour;
    [SerializeField] private StrategySwitcher _strategySwitcher;
    [SerializeField] private EnemyHP _enemyHP;
    [SerializeField] private MeleeAtack _meleeAtack;
    [SerializeField] private SoundController _soundController;
    private SignalHolder _signalHolder = new();

    private void Awake() 
    {
        _animatorSwitch.Construct(_signalHolder);
        _strategySwitcher.Construct(_signalHolder);
        _angryPigBehaviour.Construct(_signalHolder);
        _enemyHP.Construct(_signalHolder);
        _soundController.Construct(_signalHolder);
        _meleeAtack.Construct();
    }
    
}
