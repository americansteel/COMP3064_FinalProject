using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * COMP3074
 * PlayerCollision
 * 
 * Nooran El-Sherif:
 * Description: 
 * handles collisions with enemy objects
 * handles animations for player damage and death
 * 
 * Sean Price:
 * Description:
 * makes player character blink upon life taken
 */
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

			StartCoroutine ("Blink");

			if (PlayerClass.Instance.Life > 0) {
				myAnimator.ResetTrigger ("die");
			}
		}
	}
	private IEnumerator Blink(){
		//makes the player avatar flash to show damage
		Color c;
		Renderer renderer = 
			gameObject.GetComponent<Renderer> ();
		for (int i = 0; i < 3; i++) {
			for (float f = 1f; f >= 0; f -= 0.1f) {
				c = renderer.material.color;
				c.a = f;
				renderer.material.color = c;
				yield return new WaitForSeconds (.1f);
			}
			for (float f = 0f; f <= 1; f += 0.1f) {
				c = renderer.material.color;
				c.a = f;
				renderer.material.color = c;
				yield return new WaitForSeconds (.1f);
			}
		}
	}

}
