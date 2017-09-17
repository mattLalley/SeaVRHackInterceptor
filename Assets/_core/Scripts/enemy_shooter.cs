using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_shooter : MonoBehaviour
{
	public GameObject prefab;

	private player_shooter _player_shooter;
	private bool isActive;

	// Use this for initialization
	void Start()
	{
	}

	public void Activate(player_shooter playerShooter)
	{
		isActive = true;
		_player_shooter = playerShooter;
	}

	void OnEnable()
	{
        switch(GameManager.getPlayerTeam())
        {
            case Cats:
            {
                prefab = Resources.Load("cat_projectile") as GameObject;
            }
            case Dogs:
            {
                prefab = Resources.Load("dog_projectile") as GameObject;
            }
        }

	}

	// Update is called once per frame
	void Update()
	{
        if(_playerShooter == null || !isActive)
        {
            return;
        }
	
		if (Input.GetMouseButtonDown(0))
		{
			GameObject projectile = Instantiate(prefab) as GameObject;
			projectile.transform.position = transform.position + Camera.main.transform.forward * 2;
			Rigidbody rb = projectile.GetComponent<Rigidbody>();
			rb.velocity = projectile.transform.Lookat(_player_shooter) * GlobalVariables.ENEMY_SPEED;
		}

		if (Input.touchCount > 0)
		{
			var touch = Input.GetTouch(0);
			if (touch.phase == TouchPhase.Began)
			{
				GameObject projectile = Instantiate(prefab);
				projectile.transform.position = transform.position + Camera.main.transform.forward * 2;
				Rigidbody rb = projectile.GetComponent<Rigidbody>();
				rb.velocity = projectile.transform.Lookat(_player_shooter) * GlobalVariables.ENEMY_SPEED;
			}
		}
	}
} 
