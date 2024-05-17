using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private TimerSaver _timerSaver;

    public UnityEvent OnPlay;
    public UnityEvent OnPause;
    public UnityEvent OnStop;

    private DateTime _playTime;
    private TimeSpan _displayedTime;
    private TimeSpan _elapsedTime;

    private int _id;
    private TimerParameters _parameters;

    public bool IsPlay => _parameters.IsPlay;

    private void Update()
    {
        if (IsPlay)
        {
            _displayedTime = DateTime.Now - _playTime + _elapsedTime;

            DisplayTime();
        }
    }

    private void OnApplicationFocus(bool isFocused)
    {
        if (isFocused == false)
        {
            Save();
        }
        else
        {
            Load();
        }
    }

    private void OnApplicationQuit()
    {
        Save();
    }

    //private void OnApplicationPause(bool isPaused)
    //{
    //    if (isPaused)
    //    {
    //        Save();
    //    }
    //    else
    //    {
    //        Load();
    //    }
    //}

    public void SetId(int id)
    {
        _id = id;
    }

    public void OnControlButtonClick()
    {
        _parameters.IsPlay = !_parameters.IsPlay;

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
        Stop();
    }

    private void Stop()
    {
        _parameters.IsPlay = false;

        _displayedTime = TimeSpan.Zero;
        _elapsedTime = TimeSpan.Zero;

        DisplayTime();

        OnStop?.Invoke();
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

    private void DisplayTime()
    {
        _text.text = $"{_displayedTime:hh\\:mm\\:ss}";
    }

    private void Save()
    {
        _parameters.ElapsedTime = _displayedTime;

        _timerSaver.Save(_id, _parameters);
    }

    private void Load()
    {
        _parameters = _timerSaver.Load(_id);
        _elapsedTime = _parameters.ElapsedTime;

        if (IsPlay)
        {
            Play();
        }
        else
        {
            _displayedTime = _elapsedTime;

            Pause();
        }
    }
}
