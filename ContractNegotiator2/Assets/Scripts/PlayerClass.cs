using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * COMP3074
 * PlayerClass
 * 
 * Dylan Roberts - 100727526
 * Description: 
 * Handles Player instance
 * stores score and life info
 * 
 */
public class PlayerClass {

	static private PlayerClass _instance;
	static public PlayerClass Instance {
		get 
		{
			if (_instance == null) {
				_instance = new PlayerClass ();
			}
			return _instance;
		}
	} 

	private PlayerClass() {}

	public GameController gCtrl;

	private int _score = 0;
	private int _life = 3;
	private static int _highscore = PlayerPrefs.GetInt("highscore", _highscore);

	public int Score {
		get { return _score; }
		set
		{ 
			_score = value;
			if (_score > _highscore) {
				_highscore = _score;
				PlayerPrefs.SetInt ("highscore", _highscore);
			}
			gCtrl.updateUI ();
		}
	}

	public int Life{
		get { return _life; }
		set { 
			_life = value;

			if (_life <= 0) {
				gCtrl.gameOver ();
				Time.timeScale = 0;
			} else
			{
				gCtrl.updateUI ();
			}
		}
	}
}
