using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fist_shooter : MonoBehaviour {

	public GameObject prefab;
	// Use this for initialization
	void Start () {
		prefab = Resources.Load ("fish_treat") as GameObject;
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			GameObject projectile = Instantiate (prefab) as GameObject;
			projectile.transform.position = transform.position + Camera.main.transform.forward * 2;
			Rigidbody rb = projectile.GetComponent<Rigidbody>();
			rb.velocity = Camera.main.transform.forward * GlobalVariables.PLAYER_SPEED;
			//rb.angularVelocity;
		}
	}
}
