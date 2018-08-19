using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class botonCreditos : MonoBehaviour {

	private AudioSource musicaBoton;
	private Animator anim;
	// Use this for initialization
	void Start () {
		musicaBoton = GetComponent<AudioSource>();
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	}
	 void OnMouseDown(){
	 	musicaBoton.Play();
	 	SceneManager.LoadScene("creditos");
	 }
	void OnMouseOver()
    {
        anim.SetBool("encima",true);
    }
    void OnMouseExit()
    {
    	anim.SetBool("encima",false);
    }
}
