using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour
{
    [SerializeField] private Image _tutorialImagePanel;
    [SerializeField] private List<Sprite> _tutorialImages = new List<Sprite>();
    public event Action TutorialComplete;

    private int _tutorialImageIndex;
    private bool _active;

    private void Start()
    {
        _active = false;
    }

    public void Activate()
    {
        _tutorialImagePanel.sprite = _tutorialImages[0];
        _tutorialImageIndex++;
        _tutorialImagePanel.enabled = true;
        _active = true;
    }

    public void ProgressToNextPane()
    {
        if (!_active)
        {
            return;
        }
        _tutorialImagePanel.sprite = _tutorialImages[_tutorialImageIndex];
        _tutorialImageIndex++;
        if (_tutorialImageIndex == _tutorialImages.Count)
        {
            if (TutorialComplete != null)
            {
                _tutorialImagePanel.enabled = false;
                _active = false;
                TutorialComplete();
            }
        }
    }
}