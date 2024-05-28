
using UnityEngine;

public class FrutisInstaller : MonoBehaviour
{
    [SerializeField] private string[] _namesAnimations;

    public void Awake()
    {
        SetScinForFrutis();
    }

    private void SetScinForFrutis()
    {
        Frutis[] frutis = FindObjectsOfType<Frutis>();
        foreach (Frutis frut in frutis)
        {
            int randomIndex = Random.Range(0, _namesAnimations.Length - 1);
            frut.Construct(_namesAnimations[randomIndex]);
        }
    }
}
