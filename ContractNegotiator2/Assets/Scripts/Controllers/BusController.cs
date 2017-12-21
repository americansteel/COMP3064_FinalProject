using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusController : MonoBehaviour {

	[SerializeField]
	private float speed = 10f;
	[SerializeField]
	private float startX;
	[SerializeField]
	private float endX;
	[SerializeField]
	private float streetY;


	Transform _transform;
	Vector2 _currentPosition;


	// Use this for initialization
	void Start () {
		_transform = gameObject.GetComponent<Transform> ();
		_currentPosition = _transform.position;
		Reset ();
	}

	// Update is called once per frame
	void Update () {

		_currentPosition = _transform.position;
		//move bus left
		_currentPosition -= new Vector2 (speed, 0);
		_transform.position = _currentPosition;

		if (_currentPosition.x <= endX) {

			if (_currentPosition.x <= endX) {
				//reset object on leaving screen
				Destroy(this.gameObject);
			}
			Destroy(this.gameObject);
		}

	}

	void Reset (){
		_transform.position = new Vector2 (Random.Range(startX, startX + 10000), streetY);
	}
}
	
