using UnityEngine;
using UnityEngine.UI;

public class VictoryPanel : MonoBehaviour
{
    [SerializeField] private int _firstStageAchievement;
    [SerializeField] private int _secondStageAchievement;
    [SerializeField] private Image[] _imagesFrutis;

    private void Awake()
    {
        HideVictoryApple();
        DeterminVictoryApple();
    }

    private void DeterminVictoryApple()
    {
        if (GlobalScore.Score < _firstStageAchievement)
        {
            PrintVictoryApple(1);
            return;
        }

        if (GlobalScore.Score < _secondStageAchievement)
        {
            PrintVictoryApple(2);
            return;
        }

        if (GlobalScore.Score > _secondStageAchievement)
        {
            PrintVictoryApple(3);
        }
    }

    private void HideVictoryApple()
    {
        foreach(Image item in _imagesFrutis) 
        {
            item.gameObject.SetActive(false);
        }
    }    

    private void PrintVictoryApple(int countApple)
    {
        for (int i = 0; i < countApple; i++)
        {
            _imagesFrutis[i].gameObject.SetActive(true);
        }
    }

}
