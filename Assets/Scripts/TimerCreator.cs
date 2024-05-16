using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerCreator : MonoBehaviour
{
    [SerializeField] private Button _createButton;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform _container;

    private GameObject _timerObject;
    private Timer _timer;
    private int _timerId;
    private int _timersCount;

    private void OnEnable()
    {
        CreateTimers();

        _createButton.onClick.AddListener(OnCreateTimerButtonClick);
    }

    private void OnDisable()
    {
        _createButton.onClick.RemoveListener(OnCreateTimerButtonClick);
    }

    private void OnCreateTimerButtonClick()
    {
        CreateTimer();
    }

    private void CreateTimers()
    {
        LoadTimersCount();

        for (int i = 0; i < _timersCount; i++)
        {
            CreateTimer();
        }
    }

    private void CreateTimer()
    {
        _timerObject = Instantiate(_prefab, _container);
        _timerObject.transform.SetSiblingIndex(0);

        _timer = _timerObject.GetComponent<Timer>();
        _timer.SetId(_timerId++);

        SaveTimersCount();
    }

    private void SaveTimersCount()
    {
        PlayerPrefs.SetInt("TimersCount", _timerId);
    }

    private void LoadTimersCount()
    {
        _timersCount = PlayerPrefs.GetInt("TimersCount");
    }
}
