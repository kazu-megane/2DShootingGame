using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HpManager : MonoBehaviour {

	private int hp = 6;
	public Text PlayerHp;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void delHp(int targetHp){
		hp -= targetHp;
		PlayerHp.text = "HP : " + hp;
	}
}
