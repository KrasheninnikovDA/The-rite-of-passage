
using UnityEngine;

public enum DirectionMovment
{
    left = -1, 
    right = 1
}

public class RangeAtackMechanics
{
    public AtomickAction EndLifeCycleShell => _endLifeCycleShell;

    private GameObject _prefShell;
    private Transform _leftPointOfShotTransform;
    private Transform _rightPointOfShotTransform;
    private SpriteRenderer _shooterSpriteRenderer;
    private AtomickAction _endLifeCycleShell;

    public RangeAtackMechanics(GameObject prefShell, Transform leftPointOfShotTransform, 
                               Transform rightPointOfShotTransform, SpriteRenderer shooterSpriteRenderer) 
    {
        _prefShell = prefShell;
        _leftPointOfShotTransform = leftPointOfShotTransform;
        _rightPointOfShotTransform = rightPointOfShotTransform;
        _shooterSpriteRenderer = shooterSpriteRenderer;
    }

    public void Shoot()
    {
        ConstructPrefShell();
    }

    private void ConstructPrefShell()
    {
        Vector2 pointOfShot = DeterminPointOfShot(_shooterSpriteRenderer.flipX);
        GameObject shell = GameObject.Instantiate(_prefShell, pointOfShot, Quaternion.identity);
        InitShells(shell, _shooterSpriteRenderer.flipX);
    }

    private void InitShells(GameObject shell, bool flipX)
    {
        IFired firedShell = shell.GetComponent<IFired>();
        if (firedShell == null)
        {
            _endLifeCycleShell = null;
            GameObject.Destroy(shell);
            return;
        }
        _endLifeCycleShell = firedShell.EndLifeCycle;
        firedShell.ConstructShells(DeterminDirection(flipX));

    }

    private Vector2 DeterminPointOfShot(bool flipX)
    {
        
        DeterminDirection(flipX);
        if (flipX)
        {
            return _leftPointOfShotTransform.TransformDirection(_leftPointOfShotTransform.position);
        }
        return _rightPointOfShotTransform.TransformDirection(_rightPointOfShotTransform.position);
    }

    private DirectionMovment DeterminDirection(bool flipX)
    {
        if (flipX)
        {
            return DirectionMovment.left;
        }
        return DirectionMovment.right;
    }
}
