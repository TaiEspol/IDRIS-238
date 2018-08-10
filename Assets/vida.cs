using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class vida : MonoBehaviour {

	public int numVida = 5;
	int vidas;
	public Image corazoness;
	public GameObject camaraGameOver;

	// Use this for initialization
	void Start () {
		DibujarCorazones (numVida);
		vidas = numVida;
	}
	void DibujarCorazones (int cuantos) {
		Image temo;
		for(int i = 0; i < cuantos;i++) {
			temo = Instantiate<Image>(corazoness);
			temo.transform.SetParent (this.transform,false);
			temo.transform.Translate(0f + i,0f,0f) ;
			temo.name="cor" + i;
		}
	}
	void CambiarCorazon(int num,bool estat) {
		GameObject[] corazonArray;
		corazonArray = GameObject.FindGameObjectsWithTag("Corazon");
		for(int i = 0; i < corazonArray.Length;i++) {
			if(corazonArray[i].name == "cor" + num) {
				corazonArray[i].SetActive(estat);
			}
		}
	}
	public void QuitarVida() {
		vidas--;
		CambiarCorazon(vidas,false);
	}

	// Update is called once per frame
	void Update () {
        if(vidas == 0){
           camaraGameOver.SetActive(true);
        }
	}

	public int getVida() {
		return vidas;
	}
	
}
