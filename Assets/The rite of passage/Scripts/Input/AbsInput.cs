
using UnityEngine;

public abstract class AbsInput : MonoBehaviour
{
    public float HorizontalMove { protected set; get; }
    public bool JumpIsUp { protected set; get; }
    public bool JumpIsDown { protected set; get; }
    public bool Atack { protected set; get; }
    public bool FlipX { protected set; get; }
    public bool FallThroughPlatform { protected set; get; }
}
