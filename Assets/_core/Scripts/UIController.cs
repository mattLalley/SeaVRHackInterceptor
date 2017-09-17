using System.Collections;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject _gameUI;
    [SerializeField] private GameObject _panel;

    private int _happinessThreshold = 10;

    private bool _active;
    private float _panelOriginalWidth;
    private float _panelOriginalHeight;
    private float _currentWidth;
    private RectTransform _panelRect;

    private void Start()
    {
        GameManager.Instance.TreatEventOccurred += OnTreatEvent;
        _panelRect = _panel.GetComponent<RectTransform>();
        _panelOriginalWidth = _panelRect.rect.width;
        _panelOriginalHeight = _panelRect.rect.height;
        _panelRect.sizeDelta = new Vector2(0, _panelOriginalHeight);
        _currentWidth = 0;
    }

    public void Activate()
    {
        _active = true;
        _gameUI.SetActive(true);
    }

    public void Deactivate()
    {
        _active = false;
        _gameUI.SetActive(false);
    }

    private void OnTreatEvent()
    {
        float width = _panelOriginalWidth / _happinessThreshold;
        _currentWidth += width;
        if (_currentWidth < _panelOriginalWidth)
        {
            _panelRect.sizeDelta = new Vector2(_currentWidth, _panelOriginalHeight);
        }
        else
        {
            _panelRect.sizeDelta = new Vector2(_panelOriginalWidth, _panelOriginalHeight);
        }
    }
}