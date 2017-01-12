using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Clear : MonoBehaviour
{
	public MovieTexture movieTexture;
	private float wait = 0;
	private float w;
	
	void Start()
	{
		GetComponent<GUITexture>().texture = movieTexture;
		StartCoroutine (movie ());
	}
	
	IEnumerator movie(){
		movieTexture.Play ();
		yield return new WaitForSeconds (movieTexture.duration);
		Application.LoadLevel ("Title");
	}
	
	
	
}