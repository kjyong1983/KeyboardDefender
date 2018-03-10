using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	GameObject player;
	Vector3 offset = new Vector3(0,0,-10);

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player");
	}
	
	// Update is called once per frame
	void LateUpdate () {
		gameObject.transform.position = player.transform.position + offset;	
	}
}
