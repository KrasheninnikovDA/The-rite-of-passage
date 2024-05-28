using UnityEngine;
using UnityEngine.SceneManagement;

public class RepetStartMenu : MonoBehaviour
{
    public void BackInStartMenu()
    {
        SceneManager.LoadScene(NameSceneConst.StartScene);
    }
}
