using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_shooter : MonoBehaviour
{
    [SerializeField] private GameObject _catProjectile;
    [SerializeField] private GameObject _dogProjectile;
    
    private GameObject prefab;

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

        if (Input.GetMouseButtonDown(0))
        {
            GameObject projectile = Instantiate(prefab) as GameObject;
            projectile.transform.position = transform.position + Camera.main.transform.forward * 2;
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            Vector3 dir = (_player_shooter.transform.position - this.transform.position).normalized;
            rb.velocity = dir * GlobalVariables.ENEMY_SPEED;
        }

        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                GameObject projectile = Instantiate(prefab);
                projectile.transform.position = transform.position + Camera.main.transform.forward * 2;
                Rigidbody rb = projectile.GetComponent<Rigidbody>();
                Vector3 dir = (_player_shooter.transform.position - this.transform.position).normalized;
                rb.velocity = dir * GlobalVariables.ENEMY_SPEED;
            }
        }
    }
}