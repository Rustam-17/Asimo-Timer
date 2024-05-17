using UnityEngine;
using TMPro;

public class TimerTitleFitter : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputTitle;

    private TMP_Text _titleText;

    private void OnEnable()
    {
        _titleText = GetComponent<TMP_Text>();

        _inputTitle.onEndEdit.AddListener(OnEndEditTitle);
    }

    private void OnEndEditTitle(string text)
    {
        _titleText.text = text;
    }
}
