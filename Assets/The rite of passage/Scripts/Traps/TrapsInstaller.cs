using UnityEngine;

public class TrapsInstaller : MonoBehaviour
{
    [SerializeField] private MeleeAtack _meleeAtack;
    private void Awake()
    {
        _meleeAtack.Construct();
    }
}
