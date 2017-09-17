using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_projectile : MonoBehaviour {

	private float time_of_birth = 0f;
	private Vector3 _initialDirection;

	private float _acceleration = 6f;
	private float _previousTime;

	// Use this for initialization
	void Start ()
	{
		_previousTime = Time.time;
		time_of_birth = Time.fixedTime;
		_initialDirection = Camera.main.transform.forward;
		transform.position = Camera.main.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
		float deltaTime = Time.time - _previousTime;
		float yDelta = -Mathf.Pow(deltaTime, 2f) * _acceleration;
		Vector3 position = transform.position;
		position += _initialDirection * GlobalVariables.PLAYER_SPEED;
		position.y += yDelta;
		transform.position = position;

		_previousTime = Time.time;
		if (Time.fixedTime - time_of_birth > GlobalVariables.PLAYER_TIME_TO_LIVE) {
			Destroy (this.gameObject);
		}
	}
}
