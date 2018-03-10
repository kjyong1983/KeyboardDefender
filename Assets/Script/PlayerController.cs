using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour {

	float speed = 5f;
	Rigidbody2D rigidbody2d;

	const float SHOOTTIMERMAX = 0.3f;
	float shootTimer = 0;
	public GameObject missile;
	KeyboardInput keyboard;

	TextMesh textMesh;
	float deltaX = 0;
	float deltaY = 0;

	public int missileCapacity = 0;
	// Use this for initialization
	void Start () {
		rigidbody2d = GetComponent<Rigidbody2D>();
		textMesh = GetComponentInChildren<TextMesh>();
		textMesh.GetComponent<MeshRenderer>().sortingOrder = 2;
		keyboard = FindObjectOfType<KeyboardInput>();
	}
	
	// Update is called once per frame
	void Update () {
		
		textMesh.text = keyboard.GetStringBuilder();

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

		shootTimer += Time.deltaTime;
		
		if (Input.GetKeyDown(KeyCode.Space) && shootTimer > SHOOTTIMERMAX && missileCapacity > 0)
		{
			shootTimer = 0;
			missileCapacity -= 1;
			Debug.Log("Boom");
			var bullet = Instantiate(missile, transform.position, Quaternion.identity);
			bullet.GetComponent<Missile>().SetDirection(Vector2.up);
			GameObject.FindObjectOfType<GameManager>().Attack(bullet.transform.position.x);

			GameObject.Find("MissileNumber").GetComponent<Text>().text = "Missiles: " + missileCapacity;
		}


	}
}
