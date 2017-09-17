using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CharacterChooser _characterChooser;
    [SerializeField] private TutorialController _tutorialController;
    [SerializeField] private CastlePlacementController _castlePlacementController;
    [SerializeField] private player_shooter _playerShooter;
    [SerializeField] private enemy_shooter _enemyShooter;
    [SerializeField] private UIController _uiController;
    [SerializeField] private AnalyticsController _analyticsController;
    [SerializeField] private EndGameController _endGameController;

    public event Action LickEventOccurred;
    public event Action TreatEventOccurred;

    private static GameManager _instance;
    public static GameManager Instance
    {
        get { return _instance; }
    }

    private bool _petAttached;
    public bool PetAttached
    {
        get { return _petAttached;}
        set { _petAttached = value; }
    }

    private AppManager.PlayerTeam _playerTeam;
    public AppManager.PlayerTeam PlayerTeam
    {
        get { return _playerTeam; }
        set { _playerTeam = value; }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    // Use this for initialization
    private void Start()
    {
        _characterChooser.CharacterChooserComplete += OnCharacterChooserComplete;
        _tutorialController.TutorialComplete += OnTutorialComplete;
        _castlePlacementController.CastlePlacementComplete += OnCastlePlacementComplete;
        _endGameController.EndGameComplete += EndGameComplete;
        _characterChooser.Activate();
    }

    private void OnCharacterChooserComplete()
    {
        Debug.Log("CharacterChooserComplete");
        _tutorialController.Activate();
    }

    private void OnTutorialComplete()
    {
        Debug.Log("TutorialComplete");
        _castlePlacementController.Activate();
    }

    private void OnCastlePlacementComplete()
    {
        Debug.Log("CastlePlacementComplete");
        ActivateGameObjects();
    }

    private void ActivateGameObjects()
    {
        _playerShooter.Activate();
        _enemyShooter.Activate(_playerShooter);
        _uiController.Activate();
    }

    public void CompleteGame()
    {
        _playerShooter.Deactivate();
        _enemyShooter.Deactivate();
        _uiController.Deactivate();
        _endGameController.Activate();
    }

    public void EndGameComplete()
    {
        AnalyticsController.Instance.ResetAnalyticData();
        _characterChooser.Activate();
    }

    public void SendLickAnalyticEvent()
    {
        _analyticsController.LickEventOccurred();
    }

    public void SendTreatAnalyticEvent()
    {
        _analyticsController.TreatEventOccurred();
    }
}