
using UnityEngine;

public class MeleeAtack : MonoBehaviour
{
    protected DamageMechanics<PlayerHP> _damageMechanics;
    
    public void Construct()
    {
        _damageMechanics = new();
    }

    private void OnCollisionStay2D(Collision2D other) 
    {
        _damageMechanics.Hit(other);
    }
}
