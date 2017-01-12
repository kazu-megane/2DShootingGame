using UnityEngine;
using System.Collections;

public class EnemyEmitter : MonoBehaviour {

	public GameObject enemy;

	public float waitSeconds = 1.0f;
	
	IEnumerator Start () {
		while (true) {
			Vector3 emitPoint = new Vector3(Random.Range(-6.0f,6.0f), transform.position.y, transform.position.z);

			Instantiate (enemy, emitPoint, transform.rotation);

			yield return new WaitForSeconds (waitSeconds);
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
