using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

	[SerializeField]
	GameObject splash; 

	Animator myAnimator;

	private AudioSource collisionSound;
	// Use this for initialization
	void Start () {
		myAnimator = gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void OnTriggerEnter2D(Collider2D other)
	{
		collisionSound = other.GetComponent<AudioSource>();
		if (other.gameObject.tag.Equals ("car") || 
			other.gameObject.tag.Equals("bus") ||
			other.gameObject.tag.Equals("rain")){
		
			Debug.Log ("Collision with Enemy");

			if(other.gameObject.tag.Equals("rain")){
				if (collisionSound != null) {
					collisionSound.Play ();
				}

				//animate the splash
				Instantiate(splash).GetComponent<Transform>().position =
				other.gameObject.GetComponent<Transform>().position;
				
				//disappear raindrop
				Debug.Log("Collision with raindrop");

				other.gameObject.GetComponent<RainController>().Reset();

			}
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
