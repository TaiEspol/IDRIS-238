using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class botonCreditos : MonoBehaviour {

	private AudioSource musicaBoton;
	// Use this for initialization
	void Start () {
		musicaBoton = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			musicaBoton.Play();
		}
	}
	 void OnMouseDown(){
	 	SceneManager.LoadScene("creditos");
	 }
}
