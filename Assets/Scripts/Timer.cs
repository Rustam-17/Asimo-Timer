using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Button _startButton;

    private DateTime _startTime;
    private TimeSpan _pausedTime;
    private TimeSpan _elapsedTime;
    private bool _isWork;

    private void OnEnable()
    {
        _startButton.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _startButton.onClick.RemoveAllListeners();
    }

    private void Update()
    {
        if (_isWork)
        {
            _elapsedTime = DateTime.Now - _startTime + _pausedTime;
            
            _text.text = $"{_elapsedTime.ToString(@"hh\:mm\:ss")}";
        }
    }

    private void OnButtonClick()
    {
        _isWork = !_isWork;

        if (!_isWork)
        {            
            _pausedTime = _elapsedTime;
        }
        else
        {
            _startTime = DateTime.Now;
        }
    }
}
