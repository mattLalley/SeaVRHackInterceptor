﻿using UnityEngine;

public class CastleController : MonoBehaviour
{
    private readonly int HAPPINESS_THRESHOLD = 10;
    private readonly string DOG_TREAT = "dog_treat";
    private readonly string FISH_TREAT = "fish_treat";

    private bool _active;
    private int _happiness;

    public void Start()
    {
        _active = true;
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("castleController collision: " + other.collider.name);
        if (_active)
        {
            if (other.collider.name.Contains(DOG_TREAT) || other.collider.name.Contains(FISH_TREAT))
            {
                Debug.Log("Dog treat collsion (or cat treat)");
                _happiness++;
                GameManager.Instance.SendTreatAnalyticEvent();
                if (_happiness > HAPPINESS_THRESHOLD)
                {
                    CompleteGame();
                }
            }
        }
    }

    private void CompleteGame()
    {
        GameManager.Instance.CompleteGame();
    }
}