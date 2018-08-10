using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CofreController : MonoBehaviour {

	private bool tocar = false;
	private Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetBool("tocar",tocar);
	}

	void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Atacar")
        {
            tocar = true;

        }

    }
}
