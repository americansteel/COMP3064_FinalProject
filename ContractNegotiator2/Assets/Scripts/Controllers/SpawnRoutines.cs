using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRoutines : MonoBehaviour {

	public IEnumerator AddCar(GameObject car, GameObject bus)
	{
		int time = Random.Range (1, 5);
		yield return new WaitForSeconds ((float)time);
		Instantiate (car);
		StartCoroutine ("AddCar");
		if(time > 3)
		{
			AddBus(bus);
		}
	}

	public IEnumerator AddBus(GameObject bus)
	{
		int time = Random.Range (3, 10);
		yield return new WaitForSeconds ((float)time);
		Instantiate (bus);
	}
}
