using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPUI : MonoBehaviour
{
    [SerializeField] private Image[] _stackHealPoints;

    private Stack<Image> _stackHealsPoints;
    private Image _currentHeart;

    public void Construct()
    {
        EventBus.Subscribe(AllNameEvent.HealPlayer, DrowHeal);
        EventBus.Subscribe(AllNameEvent.DamagePlayer, DrowTackeDamage);
        _stackHealsPoints = new(_stackHealPoints);
    }

    private void DrowHeal()
    {
        if (_currentHeart != null)
        {
            _currentHeart.color = Color.white;
            _stackHealsPoints.Push(_currentHeart);
        }
    }

    private void DrowTackeDamage()
    {
        if (_stackHealsPoints.TryPop(out _currentHeart))
        {
            _currentHeart.color = Color.black;
        }
    }

    private void OnDisable()
    {
        EventBus.Unsubscribe(AllNameEvent.HealPlayer, DrowHeal);
        EventBus.Unsubscribe(AllNameEvent.DamagePlayer, DrowTackeDamage);
    }
}
