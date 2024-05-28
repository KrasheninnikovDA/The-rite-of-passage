using System;
using System.Collections.Generic;
using UnityEngine;

public class StrategySwitcher : MonoBehaviour
{
    [SerializeField] private AbsStrategy[] _strategies;

    private Dictionary<Type, AbsStrategy> _strategiesMap = new();
    private AbsStrategy _currentStrategy;

    public void Construct(SignalHolder signalHolder)
    {
        foreach(AbsStrategy strategy in _strategies)
        {
            strategy.Constuct(signalHolder);
            _strategiesMap.Add(strategy.GetType(), strategy);
        }
    }

    public void Switch(Type strategy)
    {
        _currentStrategy = _strategiesMap[strategy];       
    }

    private void Update() 
    {
        _currentStrategy.ControlledUpdate();
    }
}
