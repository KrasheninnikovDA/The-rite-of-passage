
public class HPControlMechanics
{
    public AtomickAction TakeDamageAction;
    public AtomickAction DeathAction;

    private Variable<int> _currentHP;
    private Timer _safePeriodTimer;
    private bool _isAlive = true;

    public HPControlMechanics(Variable<int> currentHP, float safePeriodSecods)
    {
        TakeDamageAction = new();
        DeathAction = new();
        _currentHP = currentHP;
        _safePeriodTimer = new(safePeriodSecods, TimerMode.singlnes);
    }

    public void TakeDamage()
    {
        if (!_safePeriodTimer.Runing)
        {
            _currentHP.Value--;
            CheckIsLive();
            _safePeriodTimer.Start();
            TakeDamageAction.Invoke();
        }
    }

    public void UpdateSafePeriodTimer()
    {
        _safePeriodTimer.Update();
    }

    private void CheckIsLive()
    {
        if (_currentHP.Value <= 0)
        {
            SendSignalAboutDeath();
        }
    }

    private void SendSignalAboutDeath()
    {
        if (_isAlive)
        {
            DeathAction.Invoke();
            _isAlive = false;
        }
    }
}
