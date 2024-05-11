using System;
using UnityEngine;

public class TimerSaver : MonoBehaviour
{
    TimeSpan _savedTime;
    private long _savedTicks;

    public void Save(TimeSpan elapsedTime)
    {
        _savedTicks = elapsedTime.Ticks;

        PlayerPrefs.SetString("ElapsedTime", _savedTicks.ToString());

        Debug.Log($"Saved: {elapsedTime:hh\\:mm\\:ss}");
    }

    public TimeSpan Load()
    {
        if (PlayerPrefs.HasKey("ElapsedTime"))
        {
            _savedTicks = long.Parse(PlayerPrefs.GetString("ElapsedTime"));
            _savedTime = new TimeSpan(_savedTicks);

            Debug.Log($"Load: {_savedTime:hh\\:mm\\:ss}");

            return _savedTime;
        }

        return TimeSpan.MinValue;
    }
}
