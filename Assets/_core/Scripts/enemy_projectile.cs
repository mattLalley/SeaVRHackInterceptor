using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class enemy_projectile : MonoBehaviour {
	private readonly string PLAYER_SHOOTER = "player_shooter"; 

	private float time_of_birth = 0f;
	private GameObject _analyticController;

	// Use this for initialization
	void Start ()
	{
		time_of_birth = Time.fixedTime;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.fixedTime - time_of_birth > GlobalVariables.ENEMY_TIME_TO_LIVE) {
			Destroy (this.gameObject);
		} else {
			//transform.position += (-transform.right.normalized) * GlobalVariables.ENEMY_SPEED;

			transform.position += -Camera.main.transform.forward.normalized * GlobalVariables.ENEMY_SPEED; // seeks camera out does not rotated
			transform.right = Camera.main.transform.forward;
		}
		
	}
	void OnCollisionEnter(Collision victim)
    {
		Debug.Log (victim.gameObject.name);
	    if (victim.collider.name.Contains(PLAYER_SHOOTER))
	    {
		    GameManager.Instance.SendLickAnalyticEvent();
	    }
    }
}
