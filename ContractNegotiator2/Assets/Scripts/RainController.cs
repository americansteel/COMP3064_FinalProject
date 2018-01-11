using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainController : MonoBehaviour {


	[SerializeField]
	private float minSpeed;
	[SerializeField]
	private float maxSpeed;

	private float startY = 248f;
	private float endY = -230f;
	private float [] positions = {-400f, -350f, -300f};

	Transform _transform;
	Vector2 _currentPosition;
	private float speed = 5f;

	// Use this for initialization
	void Start () {
		_transform = gameObject.GetComponent<Transform> ();
		_currentPosition = _transform.position;
		speed = Random.Range (minSpeed, maxSpeed);
	}
	
	// Update is called once per frame
	void Update () {
		
		_currentPosition = _transform.position;
		//move raindrop down
		_currentPosition -= new Vector2(0, speed); 
		_transform.position = _currentPosition;
		if (_currentPosition.y <= endY) {
			Reset ();
		}
		
	}
	public void Reset(){
		_transform.position = new Vector2 (positions [Random.Range (0, 2)], startY);
		speed = Random.Range (minSpeed, maxSpeed);

	}
}
