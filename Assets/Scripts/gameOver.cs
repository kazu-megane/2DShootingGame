using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class gameOver : MonoBehaviour {
	bool finFlg = false;

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Text> ().enabled = false;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (finFlg == true && Input.GetKey (KeyCode.R)) {
			Application.LoadLevel ("title");
		}
	
	}

	public void Lose(){
		gameObject.GetComponent<Text> ().enabled = true;
		finFlg = true;
	}
}
