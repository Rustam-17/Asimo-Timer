using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private TimerSaver _timerSaver;

    public UnityEvent OnPlay;
    public UnityEvent OnPause;
    public UnityEvent OnStop;

    private DateTime _playTime;
    private TimeSpan _elapsedTime;
    private TimeSpan _displayedTime;

    public bool IsPlay { get; private set; }

    private void Start()
    {
        _elapsedTime = _timerSaver.Load(out bool isPlay);

        IsPlay = isPlay;

        if (IsPlay)
        {
            Play();
        }
        else
        {
            OnPause?.Invoke();

            _displayedTime = _elapsedTime;

            DisplayTime();
        }
    }

    private void Update()
    {
        if (IsPlay)
        {
            _displayedTime = DateTime.Now - _playTime + _elapsedTime;

            DisplayTime();
        }
    }

    private void OnApplicationQuit()
    {
        _timerSaver.Save(_displayedTime, IsPlay);
    }

    public void OnControlButtonClick()
    {
        IsPlay = !IsPlay;

        if (IsPlay)
        {
            Play();
        }
        else
        {
            Pause();
        }
    }

    public void OnStopButtonClick()
    {
        IsPlay = false;

        OnStop?.Invoke();

        _displayedTime = TimeSpan.Zero;
        _elapsedTime = TimeSpan.Zero;

        DisplayTime();
    }

    private void Play()
    {
        OnPlay?.Invoke();

        _playTime = DateTime.Now;
    }

    private void Pause()
    {
        OnPause?.Invoke();

        _elapsedTime = _displayedTime;

        DisplayTime();
    }

    private void CalculateTime()
    {
        if (IsPlay)
        {
            _displayedTime = DateTime.Now - _playTime + _elapsedTime;
        }
    }

    private void DisplayTime()
    {
        _text.text = $"{_displayedTime:hh\\:mm\\:ss}";
    }
}
