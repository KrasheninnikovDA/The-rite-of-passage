
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionToEndScene : MonoBehaviour
{
    private void Awake()
    {
        EventBus.Subscribe(AllNameEvent.DeathPayer, TransitionToDefeatScene);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHP playerHP = collision.GetComponent<PlayerHP>();
        if (playerHP != null)
        {
            SceneManager.LoadScene(NameSceneConst.VictoryScene);
        }
    }

    private void TransitionToDefeatScene()
    {
        SceneManager.LoadScene(NameSceneConst.DefeatSCene);
    }
}
