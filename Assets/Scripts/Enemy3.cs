using UnityEngine;
using System.Collections;

public class Enemy3 : MonoBehaviour {
	public float speed;
	
	public float shotDelay;
	
	public GameObject bullet;
	
	public bool canShot;
	
	public GameObject explosion;
	
	public int scorePoint;
	
	public int hp = 1;
	
	IEnumerator Start(){
		int count = 0;
		
		while (true) {
			for (int i=0; i<transform.childCount; i++){
				Transform shotPosition = transform.GetChild(i);
				if(canShot == false){
					yield break;
				}
				Shot (shotPosition,count);
			}
			count++;
			yield return new WaitForSeconds (shotDelay);
		}
	}
	
	public void Move (Vector2 direction){
		GetComponent<Rigidbody2D> ().velocity = direction * speed;
	}
	
	public void Shot(Transform origin,int count){
		Instantiate (bullet, origin.position, origin.rotation);
	}
	
	// Update is called once per frame
	public void Update () {
		Move (transform.up * -1);
		
	}
	
	public void Explosion(){
		Instantiate (explosion, transform.position, transform.rotation);
	}
	
	void OnTriggerEnter2D(Collider2D c){
		string layerName = LayerMask.LayerToName (c.gameObject.layer);
		
		if (layerName == "Bullet(Player)") {
			Destroy (c.gameObject);
		}
		
		if (layerName == "Bullet(Player)" || layerName == "Player") {
			
			Transform bulletPlayer = c.transform.parent;
			Bullet bullet = bulletPlayer.GetComponent<Bullet>();
			hp = hp - bullet.power;
			
			if(hp <= 0){
				Explosion ();
				Destroy (gameObject);
				
				GameObject.Find ("ScoreManager").GetComponent<ScoreManager>().addScore(scorePoint);
			}
		}
	}
}
