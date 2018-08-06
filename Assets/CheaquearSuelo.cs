using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheaquearSuelo : MonoBehaviour {


	private PlayerController player;
	private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
		player = GetComponentInParent<PlayerController>();
		rb2d = GetComponentInParent<Rigidbody2D>();
	}
	
	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "Plaform") {
			rb2d.velocity = new Vector3(0f,0f,0f);
			player.transform.parent = col.transform;
			player.tocarsuelo = true;
		}
	}
	void OnCollisionStay2D(Collision2D col) {
		if(col.gameObject.tag == "Ground") {
			player.tocarsuelo = true;
		}
		
		
	}
	void OnCollisionExit2D(Collision2D col) {
		if(col.gameObject.tag == "Ground") {
			player.tocarsuelo = false;
		}
		if(col.gameObject.tag == "Plaform") {
			player.transform.parent = null;
			player.tocarsuelo = false;
		}
	}
	
}
