using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour {

	public Transform bulletSpawner;
	public GameObject bulletPrefab;

	

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		EnemyShooting();
	}

	public void EnemyShooting(){
		if (Input.GetKey("e"))
		{
			Instantiate(bulletPrefab, bulletSpawner.position, bulletSpawner.rotation);
		}
	}
}
