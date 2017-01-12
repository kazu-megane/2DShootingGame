using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public float speed = 5.0f;

	public float WaitSpace = 0.05f;

	public GameObject bullet;

	public GameObject explosion;

	public int hp = 5;
	public int hpPoint = 1;

	public gameOver gameOver;

	// Use this for initialization
	IEnumerator Start () {
		while (true) {
			Instantiate (bullet, transform.position, transform.rotation);

			GetComponent<AudioSource>().Play();

			yield return new WaitForSeconds (WaitSpace);
		}
	
	}
	
	// Update is called once per frame
	void Update () {

		float x = Input.GetAxisRaw ("Horizontal");

		float y = Input.GetAxisRaw ("Vertical");

		Vector2 direction = new Vector2 (x, y).normalized;

		GetComponent<Rigidbody2D> ().velocity = direction * speed;

		Move (direction);

	}

	public void Explosion(){
		Instantiate (explosion, transform.position, transform.rotation);
	}

	void OnTriggerExit2D(Collider2D c){
		string layerName = LayerMask.LayerToName (c.gameObject.layer);
		
		if (layerName == "Bullet(Enemy)") {
			Destroy (c.gameObject);
		}
		
		if (layerName == "Bullet(Enemy)" || layerName == "Enemy") {
			hp -= 1;
			GameObject.Find ("HpManager").GetComponent<HpManager>().delHp(hpPoint);
			if(hp <= 0){
				Explosion ();
				Destroy (gameObject);
				gameOver.Lose();
				GameObject.Find ("HpManager").GetComponent<HpManager>().delHp(hpPoint);
			}
		}
	}

	void Move(Vector2 direction){
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));

		Vector2 pos = transform.position;

		pos += direction * speed * Time.deltaTime;

		pos.x = Mathf.Clamp (pos.x, min.x, max.x);
		pos.y = Mathf.Clamp (pos.y, min.y, max.y);

		transform.position = pos;
	}
}
