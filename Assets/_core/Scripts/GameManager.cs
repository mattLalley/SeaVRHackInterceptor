using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TutorialController _tutorialController;
    [SerializeField] private CastlePlacementController _castlePlacementController;
    [SerializeField] private player_shooter _playerShooter;
    [SerializeField] private enemy_shooter _enemyShooter;
    [SerializeField] private CastleController _castleController;

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
        _tutorialController.TutorialComplete += OnTutorialComplete;
        _castlePlacementController.CastlePlacementComplete += OnCastlePlacementComplete;
        _tutorialController.Activate();
    }

    // Update is called once per frame
    private void Update()
    {
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
        _castleController.Activate();
    }
}