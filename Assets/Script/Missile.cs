using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour {

	Rigidbody2D rb;
	float speed = 15;
	Vector2 direction;

	GameObject parent;

	void Start () 
	{
		rb = GetComponent<Rigidbody2D>();
		Destroy(gameObject, 5f);
		transform.LookAt(direction);

	}
	
	void Update () 
	{
		rb.velocity = direction * speed;
	
	}

	public void SetDirection(Vector2 dir)
	{
		direction = dir;
	}

	public void SetParent(GameObject gameObject)
	{
		parent = gameObject;
	}

	public void SetSpeed(float value)
	{
		speed = value;	
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.name.Equals("Hitzone"))
		{
			Debug.Log("base attacked");
			GameObject.FindObjectOfType<GameManager>().life -= 10;
			Destroy(gameObject);
		}

		if (other.gameObject.name.Equals("enemyMissile(Clone)"))
		{
			Destroy(other.gameObject);
			Destroy(gameObject);
		}

		if (other.gameObject.CompareTag("Player") && !other.gameObject.Equals(parent))
		{
			Debug.Log("hit!");

		}
	}}
