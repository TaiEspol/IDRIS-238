using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovimiento : MonoBehaviour {

	private Rigidbody2D bulletRB;
	public float bulletSpeed;
	public float bulletLife;

	void Awake(){
		bulletRB = GetComponent<Rigidbody2D>();

	}

	// Use this for initialization
	void Start () {
		bulletRB.velocity = new Vector2(bulletSpeed, bulletRB.velocity.y);
		
	}
	
	// Update is called once per frame
	void Update () {
		Destroy(gameObject, bulletLife);
		
	}
}
