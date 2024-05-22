using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TimersHandler : MonoBehaviour
{
    [SerializeField] private TimerCreator _creator;
    [SerializeField] private TimerRemover _remover;
    [SerializeField] private TimerSaver _saver;

    private List<Timer> _timers = new List<Timer>();

    private void OnEnable()
    {
        _creator.TimerCreated.AddListener(OnTimerCreated);
        _remover.TimerRemoved.AddListener(OnTimerRemoved);
    }

    public void OnDisable()
    {
        _creator.TimerCreated.RemoveListener(OnTimerCreated);
        _remover.TimerRemoved.RemoveListener(OnTimerRemoved);
    }

    private void OnTimerCreated()
    {
        _timers.Add(_creator.Timer);
    }

    private void OnTimerRemoved()
    {
        _timers.Remove(_remover.Timer);
    }
}
