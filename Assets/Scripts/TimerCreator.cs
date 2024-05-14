using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerCreator : MonoBehaviour
{
    [SerializeField] private Button _createButton;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform _container;

    private GameObject _timer;

    private void OnEnable()
    {
        _createButton.onClick.AddListener(OnCreateTimerButtonClick);
    }

    private void OnDisable()
    {
        _createButton.onClick.RemoveListener(OnCreateTimerButtonClick);
    }

    private void OnCreateTimerButtonClick()
    {
        Create();
    }

    private void Create()
    {
        _timer = Instantiate(_prefab, _container);

        //_timer.SetParameters();
    }
}
