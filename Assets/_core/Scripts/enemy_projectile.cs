﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_projectile : MonoBehaviour {

	private float time_of_birth = 0f;

	// Use this for initialization
	void Start () {
		time_of_birth = Time.fixedTime;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.fixedTime - time_of_birth > GlobalVariables.ENEMY_TIME_TO_LIVE) {
			Destroy (this.gameObject);
		}
		
	}
	void OnCollisionEnter(Collision victim)
    {

    }
}
