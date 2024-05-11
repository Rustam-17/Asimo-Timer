using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ControlButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Image _image;
    [SerializeField] private Sprite _playSprite;
    [SerializeField] private Sprite _pauseSprite;

    private bool _isPlayed;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClick);
    }

    private void Update()
    {
        
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
