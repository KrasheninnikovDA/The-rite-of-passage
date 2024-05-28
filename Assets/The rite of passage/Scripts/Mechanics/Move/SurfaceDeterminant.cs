using UnityEngine;

public class SurfaceDeterminant 
{
    private Rigidbody2D _body;
    private Variable<bool> _isGrounded;
    private LayerMask _layer;

    public SurfaceDeterminant(Rigidbody2D body, Variable<bool> isGrounded, LayerMask layer)
    {
        _body = body;
        _isGrounded = isGrounded;
        _layer = layer;
    }

    public void ChackGround()
    {
        _isGrounded.Value = Physics2D.OverlapCircle(_body.transform.position, 0.1f, _layer);
    }

    public string DeterminSurface(Collision2D collision) 
    {
        if (_isGrounded.Value)
        {
            return collision.gameObject.tag;
        }
        return "";
    }
}
