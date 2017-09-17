using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour
{
    private enum TutorialState
    {
        Start,
        AimTowardsScreen,
        ThrowATreat,
        MakeYourPetsHappy
    }

    [SerializeField] private Image _backgroundPanel;
    [SerializeField] private Sprite _background;
    [SerializeField] private Image _aimTowardsScreen;
    [SerializeField] private Image _throwATreat;
    [SerializeField] private Image _makeYourPetsHappy;

    public event Action TutorialComplete;

    private TutorialState _tutorialState;
    private bool _active;

    private void Start()
    {
        _active = false;
    }

    public void Activate()
    {
        _backgroundPanel.sprite = _background;
        _tutorialState = TutorialState.Start;
        _backgroundPanel.enabled = true;
        _active = true;
    }

    public void ProgressToNextPane()
    {
        if (!_active)
        {
            return;
        }

        switch (_tutorialState)
        {
            case TutorialState.Start:
                _aimTowardsScreen.enabled = true;
                break;
            case TutorialState.AimTowardsScreen:
                _throwATreat.enabled = true;
                break;
            case TutorialState.ThrowATreat:
                _makeYourPetsHappy.enabled = true;
                break;
            case TutorialState.MakeYourPetsHappy:
                FinishTutorial();
                break;
        }
    }

    private void FinishTutorial()
    {
        _aimTowardsScreen.enabled = false;
        _throwATreat.enabled = false;
        _makeYourPetsHappy.enabled = false;
        if (TutorialComplete != null)
        {
            _backgroundPanel.enabled = false;
            _active = false;
            TutorialComplete();
        }
    }
}