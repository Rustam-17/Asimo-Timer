using System;
using UnityEngine;
using Newtonsoft.Json;

public class TimerSaver : MonoBehaviour
{
    private TimeSpan _savedTime;
    private long _savedTimeTicks;

    public void Save(TimeSpan elapsedTime, bool isPlay)
    {
        if (isPlay)
        {
            _savedTimeTicks = DateTime.Now.Ticks - elapsedTime.Ticks;
        }
        else
        {
            _savedTimeTicks = elapsedTime.Ticks;
        }

        PlayerPrefs.SetString("ElapsedTime", _savedTimeTicks.ToString());
        PlayerPrefs.SetString("IsPlay", isPlay.ToString());

        Debug.Log($"Saved: {elapsedTime:hh\\:mm\\:ss}");
    }

    public TimeSpan Load(out bool isPlay)
    {
        if (PlayerPrefs.HasKey("ElapsedTime"))
        {
            bool.TryParse(PlayerPrefs.GetString("IsPlay"), out isPlay);

            if (isPlay)
            {
                _savedTimeTicks = DateTime.Now.Ticks - long.Parse(PlayerPrefs.GetString("ElapsedTime"));

            }
            else
            {
                _savedTimeTicks = long.Parse(PlayerPrefs.GetString("ElapsedTime"));
            }

            _savedTime = new TimeSpan(_savedTimeTicks);

            Debug.Log($"Load: {_savedTime:hh\\:mm\\:ss}");

            return _savedTime;
        }

        Debug.Log($"There is no SaveFile to load");

        isPlay = false;
        return TimeSpan.Zero;
    }

    public void RemoveAllSaves()
    {
        PlayerPrefs.DeleteAll();

        Debug.LogWarning("All SaveFiles have been deleted!");
    }
}
