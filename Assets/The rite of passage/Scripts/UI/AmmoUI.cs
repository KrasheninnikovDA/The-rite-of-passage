using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoUI : MonoBehaviour
{
    [SerializeField] private Image[] _boomerangs;
    [SerializeField] private Image _timerRecovery;
    private Stack<Image> _stackBoomerangs;
    private Image _currentBoomerang;

    public void Construct()
    {
        Recharge();
        EventBus.Subscribe(AllNameEvent.AtackPlayer, RemovAmmo);
        EventBus.Subscribe(AllNameEvent.CatchBoomerang, AddAmmo);
        EventBus.Subscribe(AllNameEvent.Recharge, Recharge);
        EventBus.UpdateDrowTimerRecovery.Subscribe(DrawTimerRecovery);
    }

    private void AddAmmo()
    {
        if (_currentBoomerang != null)
        {
            _currentBoomerang.color = Color.white;
            _stackBoomerangs.Push(_currentBoomerang);
        }
    }

    private void RemovAmmo()
    {
        if (_stackBoomerangs.TryPop(out _currentBoomerang))
        {
            _currentBoomerang.color = Color.black;
        }
    }

    private void Recharge()
    {
        foreach (Image item in _boomerangs)
        { 
            item.color = Color.white;
        }
        _stackBoomerangs = new Stack<Image>(_boomerangs);
    }

    private void DrawTimerRecovery(float amount)
    {
        _timerRecovery.fillAmount = amount;
    }

    private void OnDisable()
    {
        EventBus.Unsubscribe(AllNameEvent.AtackPlayer, RemovAmmo);
        EventBus.Unsubscribe(AllNameEvent.CatchBoomerang, AddAmmo);
        EventBus.Subscribe(AllNameEvent.Recharge, Recharge);
        EventBus.UpdateDrowTimerRecovery.Unsubscribe(DrawTimerRecovery);
    }
}
