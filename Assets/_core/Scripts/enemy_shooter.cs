using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_shooter : MonoBehaviour
{
    [SerializeField] private GameObject _catProjectile;
    [SerializeField] private GameObject _dogProjectile;
	[SerializeField] private List<GameObject> _dogCannons;
	[SerializeField] private List<GameObject> _catCannons;
    
    private GameObject prefab;

    private player_shooter _player_shooter;
    private bool isActive;

	private float time_of_last_shot;

    // Use this for initialization
    void Start()
    {
    }

    public void Activate(player_shooter playerShooter)
    {
        isActive = true;
        _player_shooter = playerShooter;
        switch (GameManager.Instance.PlayerTeam)
        {
            case AppManager.PlayerTeam.Cats:
                prefab = _catProjectile;
                break;
            case AppManager.PlayerTeam.Dogs:
                prefab = _dogProjectile;
                break;
        }
    }

//    void OnEnable()
//    {
//    }

    // Update is called once per frame
    void Update()
    {
        if (_player_shooter == null || !isActive)
        {
            return;
        }
			
		float now = Time.fixedTime;
		if (time_of_last_shot == null || now - time_of_last_shot > GlobalVariables.ENEMY_RATE) {
			time_of_last_shot = now;
			fireAtPlayer();
		}
			
    }
	void fireAtPlayer()
	{
		GameObject projectile = Instantiate(prefab) as GameObject;
		//projectile.transform.position = new Vector3(0, 0, 0); // adjust this to be in front of a cannon

		// Aim bullet in player's direction.

		//Rigidbody rb = projectile.GetComponent<Rigidbody>();
		Vector3 dir = (_player_shooter.transform.position - projectile.transform.position).normalized;
		//var rot = projectile.transform.rotation;
		//rot.z += 90;
		dir =  Quaternion.Euler(0, -180, 0) * dir;

		//projectile.transform.forward = dir;
		projectile.transform.right = dir;

		//projectile.transform.rotation = rot;
		//rb.velocity = dir * GlobalVariables.ENEMY_SPEED;
	}
}