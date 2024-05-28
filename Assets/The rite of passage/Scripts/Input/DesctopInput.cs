
using UnityEngine;

public class DesctopInput : AbsInput
{
    private bool currentFlip = false;
    private void Update()
    {
        base.HorizontalMove = Input.GetAxis("Horizontal");
        base.JumpIsUp = Input.GetKeyDown(KeyCode.Space);
        base.JumpIsDown = Input.GetKeyUp(KeyCode.Space);
        base.Atack = Input.GetButtonDown("Fire1");
        base.FlipX = currentFlip;
        base.FallThroughPlatform = Input.GetKey(KeyCode.S);
        DeterminFlip();
    }

    public void DeterminFlip()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            currentFlip = true;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            currentFlip = false;
        }
    }
}
