using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionEnemigo : MonoBehaviour {

    public string estadoDestruir;

    public float timeForDisable;

	// Use this for initialization
    Animator anim;
    Collider2D colliderHijo;
	void Start () {
		anim = GetComponent<Animator>();
        colliderHijo = transform.GetChild(0).GetComponent<Collider2D>();
	}
	IEnumerator OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Atacar")
        {
            
            anim.Play(estadoDestruir);
            colliderHijo.enabled = false;
            yield return new WaitForSeconds(timeForDisable);
            
            /*foreach(Collider2D c in GetComponents<Collider2D>()){
                c.enabled = false;
            }*/
            
            /*float yOffset = 0.2f;
            if (transform.position.y + yOffset < col.transform.position.y)
            {
                col.SendMessage("EnemyJump");
                Destroy(gameObject);
            }
            else
            {
                col.SendMessage("EnemyKnockBack", transform.position.x);
            }*/

        }

        if (col.gameObject.tag == "Player"){
           col.SendMessage("EnemyKnockBack", transform.position.x);
        }
    }

	// Update is called once per frame
	void Update () {
		AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        if(stateInfo.IsName(estadoDestruir) && stateInfo.normalizedTime >= 0.35){
           Destroy(gameObject);
        }
	}


}
