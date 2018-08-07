using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausa : MonoBehaviour {

	bool activar;
	Canvas canvas;

	// Use this for initialization
	void Start () {
		canvas = GetComponent<Canvas>();
		canvas.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("space")) {
			activar = !activar;
			canvas.enabled = activar;
			Time.timeScale = (activar) ? 0 : 1f;
		}
	}
}
