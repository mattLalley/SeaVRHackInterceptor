using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TutorialController _tutorialController;
    [SerializeField] private CastlePlacementController _castlePlacementController;

    // Use this for initialization
    void Start()
    {
        _tutorialController.TutorialComplete += OnTutorialComplete;
        _castlePlacementController.CastlePlacementComplete += OnCastlePlacementComplete;
    }

    // Update is called once per frame
    void Update()
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
    }
}