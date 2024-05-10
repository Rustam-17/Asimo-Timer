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

    void Update()
    {
        if (_isWork)
        {
            _totalSeconds += Time.deltaTime;

            _text.text = $"{_totalSeconds.ToString()}";
        }        
    }

    private void OnButtonClick()
    {
        _isWork = !_isWork;
    }
}
