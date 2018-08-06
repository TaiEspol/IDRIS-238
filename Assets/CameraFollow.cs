using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public GameObject follow;
	public Vector2 minCamPos,maxCamPos;
	public float smoothTime;

	private Vector2 velocity;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float posX = Mathf.SmoothDamp(transform.position.x,
			follow.transform.position.x,
			ref velocity.x,smoothTime);

		transform.position =  new Vector3(
			Mathf.Clamp(posX,minCamPos.x,maxCamPos.x)
			,transform.position.y,
			transform.position.z);
	}
}
