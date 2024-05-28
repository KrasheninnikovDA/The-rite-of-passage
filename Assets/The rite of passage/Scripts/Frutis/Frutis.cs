
using UnityEngine;

public class Frutis : MonoBehaviour
{
    [SerializeField] private AnimatorFrutis _animatorFrutis;
    [SerializeField] private SoundController _soundControllerFrutis;
    [SerializeField] private float _playSoundSeconds;

    private Timer timerSound;
    private SignalHolder signalHolder;

    public void Construct(string idScin)
    {
        signalHolder = new();
        _animatorFrutis.SetScin(idScin);
        _soundControllerFrutis.Construct(signalHolder);
        timerSound = new(_playSoundSeconds, TimerMode.singlnes);
        timerSound.ActionStartTimer.Subscribe(PlaySound);
        timerSound.ActionStopTimer.Subscribe(DestroyFrutis);
    }

    private void Update()
    {
        timerSound.Update();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHP playerHP = collision.GetComponent<PlayerHP>();
        if (playerHP != null)
        {
            GlobalScore.AddScpre();
            EventBus.Invoke(AllNameEvent.AddPoint);
            timerSound.Start();
        }
    }

    private void PlaySound()
    {
        _soundControllerFrutis.Switch(AllNameSignal.PickUpAFruit);
    }

    private void DestroyFrutis()
    {
        timerSound.ActionStartTimer.Unsubscribe(PlaySound);
        timerSound.ActionStartTimer.Unsubscribe(DestroyFrutis);
        Destroy(gameObject);
    }
}
