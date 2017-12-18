using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {


	[SerializeField]
	private float speed = 7f;
	[SerializeField]
	private float startX;
	[SerializeField]
	private float endX;
	[SerializeField]
	private float streetY;


	private Transform _transform;
	private Vector2 _currentPosition;


	// Use this for initialization
	void Start () {
		_transform = gameObject.GetComponent<Transform> ();
		_currentPosition = _transform.position;
		Reset ();
	}
	
	// Update is called once per frame
	void Update () {
	
		_currentPosition = _transform.position;
		//move car left
		_currentPosition -= new Vector2 (speed, 0);

		if (_currentPosition.x < endX) {
			//reset object on leaving screen
			Reset();
		}
		_transform.position = _currentPosition;

	}

	void Reset (){
		_currentPosition = new Vector2 (Random.Range(startX, startX + 2000), streetY);
	}
}
