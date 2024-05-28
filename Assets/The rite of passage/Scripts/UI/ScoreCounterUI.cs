using TMPro;
using UnityEngine;

public class ScoreCounterUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;

    public void Construct()
    {
        _scoreText.text = GlobalScore.Score.ToString();
        EventBus.Subscribe(AllNameEvent.AddPoint, AddScore);
    }

    private void AddScore()
    {
        PrintScore(GlobalScore.Score.ToString());
    }

    private void PrintScore(string value)
    {
        _scoreText.text = value;
    }

    private void OnDisable()
    {
        EventBus.Unsubscribe(AllNameEvent.AddPoint, AddScore);
    }
}
