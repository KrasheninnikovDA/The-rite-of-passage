using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuUI : MonoBehaviour
{
    [SerializeField] private GameObject _startMenuPanel;
    [SerializeField] private GameObject _settingPanel;
    
    private GameObject _currentActivPanel;

    private void Start()
    {
        _currentActivPanel = _startMenuPanel;
        GlobalScore.ResetPoints();
    }

    public void OpenStartMenu()
    {
        SwitchPanel(_startMenuPanel);
    }

    public void OpenLevel()
    {
        SceneManager.LoadScene(NameSceneConst.LevelScene);
    }

    public void OpenSetting()
    {
        SwitchPanel(_settingPanel);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    private void SwitchPanel(GameObject panel)
    {
        _currentActivPanel.SetActive(false);
        _currentActivPanel = panel;
        _currentActivPanel.SetActive(true);
    }

}
