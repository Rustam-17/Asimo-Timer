using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimerRemover : MonoBehaviour
{
    public UnityEvent TimerRemoved;

    private Timer _timer;

    public Timer Timer => _timer;

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }

    public void Remove(Timer timer)
    {
        _timer = timer;

        TimerRemoved?.Invoke();
    }
}
