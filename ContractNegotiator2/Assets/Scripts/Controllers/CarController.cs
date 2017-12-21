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


	 Transform _transform;
	 Vector2 _currentPosition;


	// Use this for initialization
	void Start () {
		_transform = gameObject.GetComponent<Transform> ();
		Reset ();
		_currentPosition = _transform.position;

	}
	
	// Update is called once per frame
	void Update () {
	
		_currentPosition = _transform.position;
		//move car left
		_currentPosition -= new Vector2 (speed, 0);
		_transform.position = _currentPosition;

		if (_currentPosition.x <= endX) {
			//destroy object on leaving screen
				Destroy (this.gameObject);
		}
	}

	void Reset (){
		_transform.position = new Vector2 (Random.Range(startX, startX + 2000), streetY);
	}


}
