
using UnityEngine;

public class BulletMoveMechanics 
{
    private Rigidbody2D _boody;
    private int _direction;
    private float _speedBullet;

    public BulletMoveMechanics(Rigidbody2D boody, DirectionMovment startDirectionShot, float speedBullet)
    {
        _boody = boody;
        _direction = (int)startDirectionShot;
        _speedBullet = speedBullet;
    }

    public void Update()
    {
        _boody.velocity = new Vector2(_speedBullet * _direction, 0);
    }
}
