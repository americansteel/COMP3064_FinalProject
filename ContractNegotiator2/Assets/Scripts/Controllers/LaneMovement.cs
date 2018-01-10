using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneMovement : MonoBehaviour {

	[SerializeField]
	private float rainPosition1;
	[SerializeField]
	private float rainPosition2;
	[SerializeField]
	private float rainPosition3;
	private int laneChoice = 2;
	private Transform _position;
	private float _currentY;



	// Use this for initialization
	void Start () {
		_position = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		HandleInput ();
		HandleMovement ();
	}

	private void HandleMovement()
	{
		// set players x position based on the lane choice
		switch (laneChoice) {
		case 1:
			_currentY = _position.position.y;
			_position.position = new Vector2 (rainPosition1, _currentY);
			break;
		case 2:
			_currentY = _position.position.y;
			_position.position = new Vector2 (rainPosition2, _currentY);
			break;
		case 3:
			_currentY = _position.position.y;
			_position.position = new Vector2 (rainPosition3, _currentY);
			break;
		default:
			break;
		}
	}

	private void HandleInput(){
		// On A key press, set player position to first lane
		if (Input.GetKeyDown(KeyCode.A)){ 
			laneChoice = 1;
		}
		// On S key press, set player position to first lane
		if (Input.GetKeyDown(KeyCode.S)){ 
			laneChoice = 2;
		}
		// On D key press, set player position to first lane
		if (Input.GetKeyDown(KeyCode.D)){ 
			laneChoice = 3;
		}
	}
}
