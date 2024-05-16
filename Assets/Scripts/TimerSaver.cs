using System;
using System.Security.Cryptography;
using UnityEngine;

public class TimerSaver : MonoBehaviour
{
    private TimeSpan _timerElapsedTime;
    private long _timerElapsedTimeTicks;
    private int _timerId;
    private string _timerTitle;
    private bool _timerIsPlay;

    private string _titleFileName;
    private string _elapsedTimeFileName;
    private string _workStateFileName;

    private string TitleFileName => _titleFileName + _timerId;
    private string ElapsedTimeFileName => _elapsedTimeFileName + _timerId;
    private string WorkStateFileName => _workStateFileName + _timerId;

    private void OnEnable()
    {
        _titleFileName = "Title";
        _elapsedTimeFileName = "ElapsedTime";
        _workStateFileName = "WorkState";
    }

    public void Save(int id, TimerParameters parameters)
    {
        _timerId = id;
        _timerTitle = parameters.Title;
        _timerElapsedTime = parameters.ElapsedTime;
        _timerIsPlay = parameters.IsPlay;

        SaveTitle();
        SaveWorkState();
        SaveElapsedTime();

        Debug.Log($"Timer_{_timerId} {_timerTitle} saved Time: <<{_timerElapsedTime:dd} days {_timerElapsedTime:hh\\:mm\\:ss}>> in workState_{_timerIsPlay}");
    }

    public TimerParameters Load(int id)
    {
        _timerId = id;

        if (PlayerPrefs.HasKey(TitleFileName))
        {
            LoadTitle();
            LoadWorkState();
            LoadElapsedTime();

            Debug.Log($"Loaded Timer_{_timerId} {_timerTitle} Time: <<{_timerElapsedTime:dd} days {_timerElapsedTime:hh\\:mm\\:ss}>> in workState_{_timerIsPlay}");

            return new TimerParameters(_timerTitle, _timerIsPlay, _timerElapsedTime);
        }

        Debug.Log($"There is no SaveFile to load");

        return new TimerParameters();
    }

    public void RemoveAllSaves()
    {
        PlayerPrefs.DeleteAll();

        Debug.LogWarning("All SaveFiles have been deleted!");
    }

    private void SaveTitle()
    {
        PlayerPrefs.SetString(TitleFileName, _timerTitle);
    }

    private void SaveWorkState()
    {
        PlayerPrefs.SetString(WorkStateFileName, _timerIsPlay.ToString());
    }

    private void SaveElapsedTime()
    {
        if (_timerIsPlay)
        {
            _timerElapsedTimeTicks = DateTime.Now.Ticks - _timerElapsedTime.Ticks;
        }
        else
        {
            _timerElapsedTimeTicks = _timerElapsedTime.Ticks;
        }

        PlayerPrefs.SetString(ElapsedTimeFileName, _timerElapsedTimeTicks.ToString());
    }

    private void LoadTitle()
    {
        _timerTitle = PlayerPrefs.GetString(TitleFileName);
    }

    private void LoadWorkState()
    {
        bool.TryParse(PlayerPrefs.GetString(WorkStateFileName), out _timerIsPlay);
    }

    private void LoadElapsedTime()
    {
        if (_timerIsPlay)
        {
            _timerElapsedTimeTicks = DateTime.Now.Ticks - long.Parse(PlayerPrefs.GetString(ElapsedTimeFileName));
        }
        else
        {
            _timerElapsedTimeTicks = long.Parse(PlayerPrefs.GetString(ElapsedTimeFileName));
        }

        _timerElapsedTime = new TimeSpan(_timerElapsedTimeTicks);
    }
}
