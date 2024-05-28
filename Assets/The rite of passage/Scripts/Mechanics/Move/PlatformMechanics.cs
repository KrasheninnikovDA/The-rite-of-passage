
using UnityEngine;

public class PlatformMechanics 
{
    private Transform _transformPlayer;
    private bool _isAlive = true;

    public PlatformMechanics(Rigidbody2D rigidbody)
    {
        _transformPlayer = rigidbody.GetComponent<Transform>();
    }

    public void ReactToMovingPlatform(Collision2D collision)
    {
        MovingPlatform platform = collision?.gameObject.GetComponent<MovingPlatform>();
        if (platform != null)
        {
            _transformPlayer.parent = collision.transform;
        }
        else
        {
            _transformPlayer.parent = null;
        }
    }

    public void ReactionToDeath()
    {
        _isAlive = false;
    }

    public void FallThroughPlatform(Collision2D collision, bool signal)
    {
        if (signal && _isAlive)
        {
            EndToEndPaltform platform = collision.gameObject.GetComponent<EndToEndPaltform>();
            platform?.OnEnablePlatform();
        }
    }

}
