using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Button _startButton;

    private DateTime _startTime;
    private TimeSpan _elapsedTime;
    private float _totalSeconds;
    private int _seconds;
    private int _minutes;
    private int _hours;
    private int _days;
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
            _elapsedTime = DateTime.Now - _startTime;
            
            _text.text = $"{_elapsedTime.ToString(@"hh\:mm\:ss")}";
        }
    }

    private void OnButtonClick()
    {
        _isWork = !_isWork;
        _startTime = DateTime.Now + _elapsedTime;
    }
}
