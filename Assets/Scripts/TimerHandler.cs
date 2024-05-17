using UnityEngine;
using UnityEngine.UI;

public class TimerHandler : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    [SerializeField] private TimerSaver _saver;
    [SerializeField] private ControlButton _controlButton;
    [SerializeField] private Button _stopButton;

    private void OnEnable()
    {
        _timer.OnPlay.AddListener(OnTimerPlay);
        _timer.OnPause.AddListener(OnTimerPause);
        _timer.OnStop.AddListener(OnTimerStop);
        _controlButton.OnControlButtonClick.AddListener(OnControlButtonClick);
        _stopButton.onClick.AddListener(OnStopButtonClick);
    }

    private void OnDisable()
    {
        _timer.OnPlay.RemoveListener(OnTimerPlay);
        _timer.OnPause.RemoveListener(OnTimerPlay);
        _timer.OnStop.RemoveListener(OnTimerPlay);
        _controlButton.OnControlButtonClick.RemoveListener(OnControlButtonClick);
        _stopButton.onClick.RemoveListener(OnStopButtonClick);
    }

    private void OnTimerPlay()
    {
        _controlButton.OnPlay();
        _stopButton.gameObject.SetActive(true);
    }

    private void OnTimerPause()
    {
        _controlButton.OnPause();
    }

    private void OnTimerStop()
    {
        _controlButton.OnPause();
        _stopButton.gameObject.SetActive(false);
    }

    private void OnControlButtonClick()
    {
        _timer.OnControlButtonClick();
    }

    private void OnStopButtonClick()
    {
        _timer.OnStopButtonClick();
    }
}
