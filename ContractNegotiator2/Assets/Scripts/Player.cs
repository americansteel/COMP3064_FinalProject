using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	private Rigidbody2D myRigidBody;

	private Animator myAnimator;

	[SerializeField]
	private Transform[] groundPoints;

	[SerializeField]
	private float groundRadius;

	[SerializeField]
	private LayerMask whatIsGround;

	private bool isGrounded;

	private bool isJumping;

	[SerializeField]
	private float jumpForce;

	// Use this for initialization
	void Start () {
		myRigidBody = GetComponent<Rigidbody2D> ();
		myAnimator = GetComponent<Animator> ();
	}
	void Update()
	{
		HandleInput ();
	}
	// Update is called once per frame
	void FixedUpdate () {

		//check if player is grounded
		isGrounded = IsGrounded ();
		Debug.Log (isGrounded);
		HandleMovement ();
		HandleLayers ();
		Reset ();
	}

	void Reset()
	{
		isJumping = false;
		isGrounded = true;
	}
	private void HandleMovement()
	{
		if (myRigidBody.velocity.y < 0) //if falling towards ground
		{
			myAnimator.SetBool ("land", true);
		}
		//jump if on ground
		if (isGrounded && isJumping) {
			isGrounded = false; //not grounded
			myRigidBody.AddForce (new Vector2 (0, jumpForce)); //apply upward force
			myAnimator.SetTrigger("jump");
		}
		
	}
	private void HandleInput()
	{
		//if space bar is pressed, is jumping is true
		if (Input.GetKeyDown (KeyCode.Space)) {
			isJumping = true;
		}
	}
	private bool IsGrounded()
	{
		//if velocity is less than zero, falling down; if less than 0; not moving
		if (myRigidBody.velocity.y <= 0) 
		{
			foreach (Transform point in groundPoints) 
			{
			//check if colliding with something
				Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundRadius, whatIsGround);

				for (int i = 0; i < colliders.Length; i++) 
				{
					//if the collider object is not the player
					if (colliders [i].gameObject != gameObject) 
					{
						myAnimator.ResetTrigger ("jump");
						myAnimator.SetBool ("land", false);
						return true;
						Debug.Log ("player grounded");
					}
				
				}
			}
		}
		return false;
	}

	//handles ground and air layers 
	private void HandleLayers()
	{
		if (!isGrounded) //player is in air
		{
			myAnimator.SetLayerWeight (1, 1); //set weight of air layer to 1
		} 
		else //not in air
		{
			myAnimator.SetLayerWeight (1,0); //set weight of air layer to 1
		}
	}

}
	