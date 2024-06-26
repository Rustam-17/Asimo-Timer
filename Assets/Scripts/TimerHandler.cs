using UnityEngine;
using UnityEngine.UI;

public class TimerHandler : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    [SerializeField] private ControlButton _controlButton;
    [SerializeField] private Button _stopButton;
    [SerializeField] private Button _removeButton;

    private void OnEnable()
    {
        _timer.OnPlay.AddListener(OnTimerPlay);
        _timer.OnPause.AddListener(OnTimerPause);
        _timer.OnStop.AddListener(OnTimerStop);
        _controlButton.OnControlButtonClick.AddListener(OnControlButtonClick);
        _stopButton.onClick.AddListener(OnStopButtonClick);
        _removeButton.onClick.AddListener(OnRemoveButtonClick);
    }

    private void OnDisable()
    {
        _timer.OnPlay.RemoveListener(OnTimerPlay);
        _timer.OnPause.RemoveListener(OnTimerPlay);
        _timer.OnStop.RemoveListener(OnTimerPlay);
        _controlButton.OnControlButtonClick.RemoveListener(OnControlButtonClick);
        _stopButton.onClick.RemoveListener(OnStopButtonClick);
        _removeButton.onClick.RemoveListener(OnRemoveButtonClick);
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

    private void OnRemoveButtonClick()
    {
        _timer.OnRemoveButtonClick();
    }
}
