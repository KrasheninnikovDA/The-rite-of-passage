using UnityEngine;

public class UIInstaller : MonoBehaviour
{
    [SerializeField] private AmmoUI _ammoUI;
    [SerializeField] private HPUI _hpUI;
    [SerializeField] private ScoreCounterUI _scoreCounterUI;

    private void Awake()
    {
        _ammoUI.Construct();
        _hpUI.Construct();
        _scoreCounterUI.Construct();
    }
}
