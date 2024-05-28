
using UnityEngine;

public class AnimatorFrutis : MonoBehaviour
{
    [SerializeField] private Animator _animatorFrutis;
    private string _nameAnimation;

    public void SetScin(string nameAnimation)
    {
        _nameAnimation = nameAnimation;
    }

    private void Update()
    {
        _animatorFrutis.Play(_nameAnimation);
    }
}
