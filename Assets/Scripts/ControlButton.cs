using UnityEngine;
using UnityEngine.UI;

public class ControlButton : MonoBehaviour
{
    //[SerializeField] private Timer _timer;
    [SerializeField] private Sprite _playSprite;
    [SerializeField] private Sprite _pauseSprite;

    private Button _button;
    private Image _image;
    private bool _isPlayed;

    private void OnDisable()
    {
        _button.onClick.RemoveAllListeners();
    }

    private void Start()
    {
        _button = GetComponent<Button>();
        _image = GetComponent<Image>();
        _isPlayed = false;

        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        _isPlayed = !_isPlayed;

        if (_isPlayed)
        {
            _image.sprite = _pauseSprite;
        }
        else
        {
            _image.sprite = _playSprite;
        }
    }
}
