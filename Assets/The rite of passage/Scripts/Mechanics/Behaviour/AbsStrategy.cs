
using UnityEngine;

public abstract class AbsStrategy : MonoBehaviour
{
    public abstract void Constuct(SignalHolder signalHolder);
    
    public abstract void ControlledUpdate();

}
