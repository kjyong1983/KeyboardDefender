using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	float speed = 5f;
	Rigidbody2D rigidbody2d;

	float deltaX = 0;
	float deltaY = 0;
	// Use this for initialization
	void Start () {
		rigidbody2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetAxisRaw("Horizontal") != 0)
		{
			deltaX = Input.GetAxisRaw("Horizontal") * speed;
		}
		else
		{
			deltaX = 0;
		}
		if (Input.GetAxisRaw("Vertical") != 0)
		{
			deltaY = Input.GetAxisRaw("Vertical") * speed;
		}
		else
		{
			deltaY = 0;
		}

		rigidbody2d.velocity = new Vector2(deltaX, deltaY);

	}
}
