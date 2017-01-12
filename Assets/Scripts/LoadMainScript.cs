using UnityEngine;
using System.Collections;

public class LoadMainScript : MonoBehaviour {
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.A)) {
			Application.LoadLevel ("Level1");
		}
	
	}
}
