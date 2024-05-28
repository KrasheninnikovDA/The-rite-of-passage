
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGameplay : MonoBehaviour
{
    [SerializeField] private GameObject panelMenu;

    private void Start()
    {
        panelMenu.SetActive(false);    
    }

    public void OpenMenu()
    {
        Time.timeScale = 0;
        panelMenu.SetActive(true);
    }

    public void CloseMenu() 
    {
        panelMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Repeat()
    {
        Transition(NameSceneConst.LevelScene);
    }

    public void TansitionInStartMenu()
    {
        Transition(NameSceneConst.StartScene);
    }

    private void Transition(int numberScene)
    {
        Time.timeScale = 1f;
        GlobalScore.ResetPoints();
        SceneManager.LoadScene(numberScene);
    }
}
