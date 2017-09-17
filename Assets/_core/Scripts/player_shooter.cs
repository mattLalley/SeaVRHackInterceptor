using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_shooter : MonoBehaviour
{
    public GameObject prefab;

	private bool isActive;

    // Use this for initialization
    void Start()
    {
    }

	public void Activate()
	{
		isActive = true;
	}
	
	void OnEnable()
	{
		if (PLAYER_TEAM)
		{
			prefab = Resources.Load("fish_treat") as GameObject;
		}
		else {
			prefab = Resources.Load("bone_treat") as GameObject;
		}

	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject projectile = Instantiate(prefab) as GameObject;
            projectile.transform.position = transform.position + Camera.main.transform.forward * 2;
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            rb.velocity = Camera.main.transform.forward * 30;
        }

        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                GameObject projectile = Instantiate(prefab);
                projectile.transform.position = transform.position + Camera.main.transform.forward * 2;
                Rigidbody rb = projectile.GetComponent<Rigidbody>();
                rb.velocity = Camera.main.transform.forward * 30;
            }
        }
    }
}