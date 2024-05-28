
using UnityEngine;

public class ArrowPlantInstaller : MonoBehaviour
{
    [SerializeField] private ArrowPlantAnimatorSwitcher _arrowPlantAnimatorSwitcher;
    [SerializeField] private EnemyHP _enemyHP;
    [SerializeField] private StrategySwitcher _strategySwitcher;
    [SerializeField] private ArrowPlantBehaviour _arrowPlantBehaviour;
    [SerializeField] private SoundController _soundController;

    private SignalHolder arrowPlantSignalHolder;
    
    private void Awake() 
    {
        arrowPlantSignalHolder = new();
        _arrowPlantAnimatorSwitcher.Construct(arrowPlantSignalHolder);
        _enemyHP.Construct(arrowPlantSignalHolder);
        _strategySwitcher.Construct(arrowPlantSignalHolder);
        _arrowPlantBehaviour.Construct(arrowPlantSignalHolder);
        _soundController.Construct(arrowPlantSignalHolder);
    }
}   
