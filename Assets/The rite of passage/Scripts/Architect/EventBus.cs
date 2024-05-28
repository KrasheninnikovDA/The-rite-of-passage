
using System;
using System.Collections.Generic;

public enum AllNameEvent
{
    AtackPlayer,
    CatchBoomerang,
    AddPoint,
    Recharge,
    DamagePlayer,
    HealPlayer,
    DeathPayer,
}
public static class EventBus
{
    public static AtomickEvent<float> UpdateDrowTimerRecovery = new();

    private static Dictionary<AllNameEvent, AtomickAction> allEvent = new();

    public static void Subscribe(AllNameEvent nameEvent, Action action)
    {
        if (!allEvent.ContainsKey(nameEvent))
        {
            allEvent.Add(nameEvent, new AtomickAction());
        }
        allEvent[nameEvent].Subscribe(action);
    }

    public static void Unsubscribe(AllNameEvent nameEvent, Action action)
    {
        if (allEvent.ContainsKey(nameEvent))
        {
            allEvent[nameEvent].Unsubscribe(action);
        }
    }

    public static void Invoke(AllNameEvent nameEvent)
    {
        if (allEvent.ContainsKey(nameEvent))
        {
            allEvent[nameEvent]?.Invoke();
        }
    }
}
