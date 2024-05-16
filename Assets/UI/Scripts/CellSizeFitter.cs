using UnityEngine;
using UnityEngine.UI;

public class CellSizeFitter : MonoBehaviour
{
    [SerializeField] private GridLayoutGroup _gridLayoutGroup;
    [SerializeField] private float _offsetX;

    private float _cellSizeX;
    private float _cellSizeY;
    private Vector2 _cellSize;

    void Start()
    {
        _cellSizeX = Screen.width - 2 * _offsetX;
        _cellSizeY = _gridLayoutGroup.cellSize.y;
        _cellSize = new Vector2(_cellSizeX, _cellSizeY);

        _gridLayoutGroup.cellSize = _cellSize;
    }
}
