﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

	Animator myAnimator;
	// Use this for initialization
	void Start () {
		myAnimator = gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag.Equals ("car") || 
			other.gameObject.tag.Equals("bus")) {

			Debug.Log ("Collision with Enemy");

			myAnimator.SetTrigger ("die");
			PlayerClass.Instance.Life -= 1;
			if (PlayerClass.Instance.Life > 0) {
				myAnimator.ResetTrigger ("die");
			}
		}
	}
}
