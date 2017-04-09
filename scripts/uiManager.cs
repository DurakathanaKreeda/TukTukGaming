using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class uiManager : MonoBehaviour {
	public Text scoreText;
	int score;
	bool gameOver;
	public Button[] buttons;
	public AudioManager am;

	// Use this for initialization
	void Start () {
		gameOver = false;
		InvokeRepeating ("ScoreUpdate", 1.0f, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = "Score: " + score;
	}

	void ScoreUpdate(){
		if (!gameOver) {
			score += 1;
		}
	}

	public void Pause () {
		if (Time.timeScale == 0) {
			Time.timeScale = 1;
			am.carSound.Play ();
		} else if (Time.timeScale == 1) {
			Time.timeScale = 0;
			am.carSound.Pause ();
		}
	}

	public void Play () {
		Application.LoadLevel ("level1");
	}

	public void Replay() {
		Application.LoadLevel (Application.loadedLevel);
	}

	public void Menu(){
		Application.LoadLevel ("menu");
	}

	public void GameOver(){
		gameOver = true;
		foreach (Button button in buttons) {
			button.gameObject.SetActive(true);
		}
	}
}
