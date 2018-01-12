using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	[SerializeField]
	GameObject car;
	[SerializeField]
	GameObject bus;
	[SerializeField]
	Text lifeLabel;
	[SerializeField]
	Text scoreLabel;
	[SerializeField]
	Text gameOverLabel;
	[SerializeField]
	Text highScoreLabel;
	[SerializeField]
	Button resetButton;

	private void initialize(){

		if (SceneManager.GetActiveScene ().buildIndex == 2) {
			PlayerClass.Instance.Score = 0;
			PlayerClass.Instance.Life = 3;
		}
		gameOverLabel.gameObject.SetActive (false);
		highScoreLabel.gameObject.SetActive (false);
		lifeLabel.gameObject.SetActive (true);
		scoreLabel.gameObject.SetActive (true);
		resetButton.gameObject.SetActive (false);
	
	}

	public void gameOver(){
		gameOverLabel.gameObject.SetActive (true);
		highScoreLabel.gameObject.SetActive (true);
		resetButton.gameObject.SetActive (true);
		lifeLabel.gameObject.SetActive (false);
		scoreLabel.gameObject.SetActive (false);
	}

	public void updateUI(){

		scoreLabel.text = "Score: " + PlayerClass.Instance.Score;
		lifeLabel.text = "Life: " + PlayerClass.Instance.Life;
		highScoreLabel.text = "High Score: " + PlayerPrefs.GetInt ("highscore");
	}


	// Use this for initialization
	void Start () {
		PlayerClass.Instance.gCtrl = this;
		initialize ();
		StartCoroutine( AddCar(car, bus) );
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ResetButtonClick() {
		SceneManager.LoadScene(2);
	}
	public void LevelTwoButtonClick(){
		SceneManager.LoadScene (3);
	}

	public IEnumerator AddCar(GameObject car, GameObject bus)
	// spawns a car in a random amount of time. if it took a while (5s) it spawns a bus too.
	{
		int time = Random.Range (1, 5);
		yield return new WaitForSeconds ((float)time);
		Instantiate (car);
		StartCoroutine (AddBus(bus));
		if(time > 4)
		{
			AddBus(bus);
		}
		StartCoroutine (AddCar(car,bus));
	}

	public IEnumerator AddBus(GameObject bus)
	// adds a bus to the scene
	{
		int time = Random.Range (3, 10);
		yield return new WaitForSeconds ((float)time);
		Instantiate (bus);
	}
}
