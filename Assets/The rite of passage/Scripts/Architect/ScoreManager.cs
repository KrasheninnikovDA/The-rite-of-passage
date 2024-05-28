
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;

    private void Start()
    {
        _scoreText.text = GlobalScore.Score.ToString();
    }

    public void ResetPoints()
    {
        GlobalScore.ResetPoints();
    }
}
