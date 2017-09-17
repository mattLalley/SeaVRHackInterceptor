using System;
using UnityEngine;
using UnityEngine.UI;

public class EndGameController : MonoBehaviour
{
    [SerializeField] private Image _backgroundPanel;
    [SerializeField] private Sprite _dogSuccessImage;
    [SerializeField] private Sprite _catSuccessImage;

    private bool _active;

    public event Action EndGameComplete;

    public void Activate()
    {
        _active = true;
        switch (GameManager.Instance.PlayerTeam)
        {
            case AppManager.PlayerTeam.Cats:
                _backgroundPanel.sprite = _catSuccessImage;
                break;
            case AppManager.PlayerTeam.Dogs:
                _backgroundPanel.sprite = _dogSuccessImage;
                break;
        }
    }

    public void RestartButtonPressed()
    {
        EndGameComplete();
    }
}