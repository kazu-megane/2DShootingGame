using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	private int score = 0;
	public Text scoreText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void addScore(int targetScore){
		score += targetScore;
		scoreText.text = "Score : " + score;

		if (score >= 20) {
			Application.LoadLevel ("change");
		}
	}
}
