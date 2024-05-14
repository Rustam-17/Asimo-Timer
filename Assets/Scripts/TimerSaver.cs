using System;
using UnityEngine;

public class TimerSaver : MonoBehaviour
{
    private TimeSpan _savedTime;
    private long _savedTimeTicks;
    private string _titleFileName;
    private string _timeFileName;
    private string _workStateFileName;

    private string TimeFileName => _timeFileName + _titleFileName;
    private string WorkStateFileName => _workStateFileName + _titleFileName;

    public void Save(TimerParameters parameters)
    {
        if (parameters.IsPlay)
        {
            _savedTimeTicks = DateTime.Now.Ticks - parameters.ElapsedTime.Ticks;
        }
        else
        {
            _savedTimeTicks = parameters.ElapsedTime.Ticks;
        }

        _titleFileName = parameters.Title;

        PlayerPrefs.SetString(_titleFileName, parameters.Title.ToString());
        PlayerPrefs.SetString(TimeFileName, _savedTimeTicks.ToString());
        PlayerPrefs.SetString(WorkStateFileName, parameters.IsPlay.ToString());

        Debug.Log($"Timer {_titleFileName} saved <<{parameters.ElapsedTime:hh\\:mm\\:ss}>> in state: work_{parameters.IsPlay}");
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
