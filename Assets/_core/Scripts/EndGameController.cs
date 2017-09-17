using System;
using UnityEngine;
using UnityEngine.UI;

public class EndGameController : MonoBehaviour
{
    [SerializeField] private Image _backgroundPanel;
    [SerializeField] private Sprite _dogSuccessImage;
    [SerializeField] private Sprite _catSuccessImage;
    [SerializeField] private Text _treatsNumber;
    [SerializeField] private Text _licksNumber;
    [SerializeField] private GameObject _endGameUI;

    private bool _active;

    public event Action EndGameComplete;

    public void Activate()
    {
        _active = true;
        _endGameUI.SetActive(true);
        switch (GameManager.Instance.PlayerTeam)
        {
            case AppManager.PlayerTeam.Cats:
                _backgroundPanel.sprite = _catSuccessImage;
                break;
            case AppManager.PlayerTeam.Dogs:
                _backgroundPanel.sprite = _dogSuccessImage;
                break;
        }
        
        SetNumberOfLicks();
        SetNumberOfTreats();
    }

    private void SetNumberOfLicks()
    {
        int numberOfLicks = AnalyticsController.Instance.NumberOfLicks;
        _licksNumber.text = String.Format("{0}", numberOfLicks);
    }

    private void SetNumberOfTreats()
    {
        int numberOfTreats = AnalyticsController.Instance.NumberOfTreats;
        _treatsNumber.text = String.Format("{0}", numberOfTreats);
    }

    public void RestartButtonPressed()
    {
        _active = false;
        _endGameUI.SetActive(false);
        EndGameComplete();
    }
}