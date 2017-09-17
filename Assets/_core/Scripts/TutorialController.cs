using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour
{
    private enum TutorialState
    {
        AimTowardsScreen,
        ThrowATreat,
        MakeYourPetsHappy,
        Complete
    }

    [SerializeField] private Image _backgroundPanel;
    [SerializeField] private Sprite _backgroundImage;
    [SerializeField] private GameObject _aimTowardsScreen;
    [SerializeField] private GameObject _throwATreat;
    [SerializeField] private GameObject _makeYourPetsHappy;

    public event Action TutorialComplete;

    private TutorialState _tutorialState;
    private bool _active;

    private void Start()
    {
        _active = false;
    }

    public void Activate()
    {
        _backgroundPanel.sprite = _backgroundImage;
        _tutorialState = TutorialState.AimTowardsScreen;
        _backgroundPanel.enabled = true;
        _active = true;
    }

    public void ProgressToNextPane()
    {
        Debug.Log("ProgressToNextPane: " + _tutorialState);
        if (!_active)
        {
            return;
        }

        switch (_tutorialState)
        {
            case TutorialState.AimTowardsScreen:
                _aimTowardsScreen.SetActive(true);
                _tutorialState = TutorialState.ThrowATreat;
                break;
            case TutorialState.ThrowATreat:
                _tutorialState = TutorialState.MakeYourPetsHappy;
                _throwATreat.SetActive(true);
                break;
            case TutorialState.MakeYourPetsHappy:
                _tutorialState = TutorialState.Complete;
                _makeYourPetsHappy.SetActive(true);
                break;
            case TutorialState.Complete:
                FinishTutorial();
                break;
        }
    }

    private void FinishTutorial()
    {
        _aimTowardsScreen.SetActive(false);
        _throwATreat.SetActive(false);
        _makeYourPetsHappy.SetActive(false);
        if (TutorialComplete != null)
        {
            _backgroundPanel.enabled = false;
            _active = false;
            TutorialComplete();
        }
    }
}