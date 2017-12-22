using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * COMP3074
 * Dylan Roberts
 * BackgroundController
 * Description: 
 * control scrolling of background in game
 */
public class BackgroundController : MonoBehaviour {

	//Public variables
	[SerializeField]
	private float speed = 5f;
	[SerializeField]
	private float startX;
	[SerializeField]
	private float endX;

	//private variables
	private Transform _transform;
	private Vector2 _currentPos;

	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
		_transform = gameObject.GetComponent<Transform> ();
		_currentPos = _transform.position;
		Reset ();
	}

	// Update is called once per frame
	void Update () {

		if (Time.timeScale != 0) {
			_currentPos = _transform.position;
			//move ocean down
			_currentPos -= new Vector2 (speed, 0);

			//check if we need to reset
			if (_currentPos.x < endX) {
				//reset
				Reset ();
			}
			//apply changes
			PlayerClass.Instance.Score += 1;
			_transform.position = _currentPos;
		}
	}


	private void Reset(){
		_currentPos = new Vector2 (startX, 0);
	}
}
