using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quit : MonoBehaviour {

	// Use this for initialization
	public void doquit () {
		Debug.Log("Salió del juego");
		Application.Quit();
	}
	
}
