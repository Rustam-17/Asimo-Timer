using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TimerCreator : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform _container;
    [SerializeField] private Button _createButton;
    [SerializeField] private TimerSaver _timerSaver;
    [SerializeField] private TimerRemover _timerRemover;

    public UnityEvent TimerCreated;

    private GameObject _timerObject;
    private Timer _timer;
    //private int _timerId;
    private int _timersCount;

    public Timer Timer => _timer;

    private void OnEnable()
    {
        _createButton.onClick.AddListener(CreateTimer);
        _timerRemover.TimerRemoved.AddListener(OnTimerRemoved);
        CreateTimers();
    }

    private void OnDisable()
    {
        _createButton.onClick.RemoveListener(CreateTimer);
    }

    public void CreateTimer()
    {
        _timerObject = Instantiate(_prefab, _container);
        _timerObject.transform.SetSiblingIndex(0);

        _timer = _timerObject.GetComponent<Timer>();
        _timer.SetId(_timersCount++);
        _timer.SetComponents(_timerSaver, _timerRemover);

        SaveTimersCount();
    }

    private void CreateTimers()
    {
        LoadTimersCount();

        for (int i = 0; i < _timersCount; i++)
        {
            CreateTimer();
        }
    }

    private void SaveTimersCount()
    {
        PlayerPrefs.SetInt("TimersCount", _timersCount);        
    }

    private void LoadTimersCount()
    {
        _timersCount = PlayerPrefs.GetInt("TimersCount");
    }

    private void OnTimerRemoved()
    {
        _timersCount--;
        SaveTimersCount();
    }
}
