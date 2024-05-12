using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ControlButton : MonoBehaviour
{
    [SerializeField] private Sprite _playSprite;
    [SerializeField] private Sprite _pauseSprite;
    [SerializeField] private Button _button;

    public UnityEvent OnControlButtonClick;

    private Image _image;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveAllListeners();
    }

    private void Start()
    {
        _image = GetComponent<Image>();
    }

    public void OnPlay()
    {
        _image.sprite = _pauseSprite;
    }

    public void OnPause()
    {
        _image.sprite = _playSprite;
    }

    private void OnClick()
    {
        OnControlButtonClick?.Invoke();
    }
}
