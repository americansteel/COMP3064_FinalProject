using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIController : MonoBehaviour {

	public void ChangeScene(int sceneId) {

		//load scene thats passed in
		SceneManager.LoadScene(sceneId);
	}
}