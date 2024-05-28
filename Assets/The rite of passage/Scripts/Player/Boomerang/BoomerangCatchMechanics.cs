using UnityEngine;

public class BoomerangCatchMechanics 
{
    private AtomickAction _collisionAction;
    private AtomickAction _endLifeCycle;

    public BoomerangCatchMechanics(AtomickAction collisionAction, AtomickAction endLifeCycle)
    {
        _collisionAction = collisionAction;
        _endLifeCycle = endLifeCycle;
    }

    public void HandleCollision(Collision2D collision)
    {
        PlayerShooter playerShooter = collision.gameObject.GetComponent<PlayerShooter>();

        if (playerShooter != null) 
        {
            playerShooter.AddShall();
            _endLifeCycle?.Invoke();
            EventBus.Invoke(AllNameEvent.CatchBoomerang);
            return;
        }
        _collisionAction?.Invoke();
    }
}
