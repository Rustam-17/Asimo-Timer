using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Button _controlButton;
    [SerializeField] private Button _stopButton;
    [SerializeField] private TimerSaver _timerSaver;

    public UnityEvent OnStart;
    public UnityEvent OnPause;
    public UnityEvent OnStop;

    private DateTime _startTime;
    private TimeSpan _elapsedTime;
    private TimeSpan _displayedTime;
    private bool _isWork;

    private void OnEnable()
    {
        _controlButton.onClick.AddListener(OnControlButtonClick);
        _stopButton.onClick.AddListener(OnStopButtonClick);
    }

    private void OnDisable()
    {
        _controlButton.onClick.RemoveListener(OnControlButtonClick);
        _stopButton.onClick.RemoveListener(OnStopButtonClick);
    }

    private void Start()
    {
        _elapsedTime = _timerSaver.Load();
    }

    private void Update()
    {
        if (_isWork)
        {
            _displayedTime = DateTime.Now - _startTime + _elapsedTime;

            _text.text = $"{_displayedTime:hh\\:mm\\:ss}";
        }
    }

    private void OnApplicationQuit()
    {
        _timerSaver.Save(_displayedTime);
    }

    private void OnControlButtonClick()
    {
        _isWork = !_isWork;

        if (_isWork)
        {
            OnStart?.Invoke();

            _startTime = DateTime.Now;
        }
        else
        {
            OnPause?.Invoke();

            _elapsedTime = _displayedTime;
        }
    }

    private void OnStopButtonClick()
    {
        _isWork = false;

        OnStop?.Invoke();

        _displayedTime = TimeSpan.Zero;
        _elapsedTime = TimeSpan.Zero;
    }

    //private void OnApplicationFocus(bool isPaused)
    //{
    //    if (isPaused)
    //    {
    //        Save();
    //        PlayerPrefs.Save();
    //    }
    //    else
    //    {
    //        Load();
    //    }
    //}
}
