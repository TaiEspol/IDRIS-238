using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float maxSpeed = 6f;
	public float speed = 3f;
	public bool tocarsuelo;
	public float fuerzaSalto = 6.5f;
	public GameObject vidas;

	private vida live;
	private Rigidbody2D rb2d;
	private Animator anim;
	private SpriteRenderer spr;
	private bool saltar;
	private bool dobleSalto;
	private bool moviendo = true;

	CircleCollider2D colliderAtaque;
	Vector2 mov;
	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		spr = GetComponent<SpriteRenderer>();
		live = vidas.GetComponent<vida>();
		colliderAtaque = transform.GetChild(1).GetComponent<CircleCollider2D>();
		colliderAtaque.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		mov = new Vector2(Input.GetAxisRaw("Horizontal"),
			Input.GetAxisRaw("Vertical"));

		anim.SetFloat("speed",Mathf.Abs(rb2d.velocity.x));
		anim.SetBool("tocar suelo",tocarsuelo);

		AnimatorStateInfo infoEstado = anim.GetCurrentAnimatorStateInfo(0); 
		bool atacando = infoEstado.IsName("Player_atacar");
		
		if(Input.GetKey(KeyCode.X) && !atacando) {
			anim.SetTrigger("atacar");
		}
		if(atacando){
			float playbackTime = infoEstado.normalizedTime;
			if(playbackTime > 0.0 && playbackTime < 0.8) colliderAtaque.enabled = true;
			else colliderAtaque.enabled = false;
		}
		

		if(Input.GetKeyDown(KeyCode.UpArrow)) {
			if(tocarsuelo){
				saltar = true;
				dobleSalto = true;
			}else if(dobleSalto){
				saltar = true;
				dobleSalto = false;
			}
		}


	}
	void FixedUpdate () {

		Vector3 fixedVelocity = rb2d.velocity;
		fixedVelocity.x *= 0.75f;

		if(tocarsuelo){
			rb2d.velocity = fixedVelocity;
		}
		
		float ejeHorizontal = Input.GetAxis("Horizontal");
		if(!moviendo) ejeHorizontal = 0;

		rb2d.AddForce(Vector2.right * speed * ejeHorizontal);

		/*if (rb2d.velocity.x > maxSpeed){
			rb2d.velocity = new Vector2(maxSpeed,rb2d.velocity.y);
		}

		if (rb2d.velocity.x < -maxSpeed){
			rb2d.velocity = new Vector2(-maxSpeed,rb2d.velocity.y);
		}*/
		float limitedSpeed = Mathf.Clamp(rb2d.velocity.x,-maxSpeed,maxSpeed);
		rb2d.velocity = new Vector2(limitedSpeed,rb2d.velocity.y);

		//cambiar la escala o la cara del jugador, si va a la izquierda o derecha
		if(ejeHorizontal > 0.1f) {
			transform.localScale = new Vector3(1f,1f,1f);
		}

		if(ejeHorizontal < -0.1f) {
			transform.localScale = new Vector3(-1f,1f,1f);
		}

		if(saltar) {
			rb2d.velocity = new Vector2(rb2d.velocity.x,0);
			rb2d.AddForce(Vector2.up * fuerzaSalto,ForceMode2D.Impulse);
			saltar = false;
		}
	}


	public void EnemyJump(){
		saltar = true;
	}

	public void EnemyKnockBack(float enemyPosx){
		saltar = true;

		float side = Mathf.Sign(enemyPosx - transform.position.x);
		rb2d.AddForce(Vector2.left * side * fuerzaSalto,ForceMode2D.Impulse );

		moviendo = true;
		Invoke("ActivarMovimiento",0.7f);
		spr.color = Color.red;
		 
		Invoke("Quitarlive",0.1f);
	}
	void ActivarMovimiento(){
		moviendo = true;
		spr.color = Color.white;
	}

	void Quitarlive(){
		live.QuitarVida();
		transform.position = new Vector3(0,0,0);
	}
}
