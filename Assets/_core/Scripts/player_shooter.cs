using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_shooter : MonoBehaviour
{
    [SerializeField] private GameObject _fishTreat;
    [SerializeField] private GameObject _boneTreat;

    private GameObject prefab;

	private bool isActive;

    // Use this for initialization
    void Start()
    {
    }

	public void Activate()
	{
	    Debug.Log("Activate play shooter");
		isActive = true;
        switch(GameManager.Instance.PlayerTeam)
        {
            case AppManager.PlayerTeam.Cats:
                prefab = _fishTreat;
                break;
            case AppManager.PlayerTeam.Dogs:
                prefab = _boneTreat;
                break;
		    default:
				prefab = _boneTreat;
				break;
        }
	}
	
//	void OnEnable()
//	{
//
//	}

    // Update is called once per frame
    void Update()
    {
        if(!isActive)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(prefab);
        }

        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Instantiate(prefab);
            }
        }
    }

    public void Deactivate()
    {
        isActive = false;
    }
}
