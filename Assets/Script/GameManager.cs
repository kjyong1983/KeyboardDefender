using SocketIO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	
	public int life = 100;
	int mana = 100;
	int score = 0;
	bool isCorrect = false;

	private string myName;

	KeyboardInput keyboardInput;
	Questions questions;

	GameObject player;
	Text missileNumber;
	Text HP;

	public GameObject missile;
	KDNetwork kdNetwork;

	// Use this for initialization
	void Start () {
		myName = PlayerPrefs.GetString("NAME");

		keyboardInput = FindObjectOfType<KeyboardInput>();
		questions = FindObjectOfType<Questions>();
		player = GameObject.FindWithTag("Player");

		kdNetwork = new KDNetwork(GameObject.Find("SocketIO").GetComponent<SocketIOComponent>());
		kdNetwork.OnOpen += OnOpen;
		kdNetwork.BeAttacked += BeAttacked;

		missileNumber = GameObject.Find("MissileNumber").GetComponent<Text>();
		missileNumber.text = "Missiles: 0";
		HP = GameObject.Find("HP").GetComponent<Text>();
		HP.text = "HP: 100";
	}
	
	// Update is called once per frame
	void Update () {
		HP.text = "HP: " + life.ToString();
	}

	public void CompareAnswer(string answer)
	{
		// isCorrect = questions.IsSame(answer);
		isCorrect = FindObjectOfType<Questions>().CheckAnswers(answer);
		if (isCorrect)
		{
			// score += 100;
			if (player.GetComponent<PlayerController>().missileCapacity <= 5)
			{
				player.GetComponent<PlayerController>().missileCapacity += 1;
				missileNumber.text = "Missiles: " + player.GetComponent<PlayerController>().missileCapacity;				
			}
			Debug.Log("correct!");
		}
		else
		{
			Debug.Log("nah");
		}
	}

	public void Attack(float coordX)
	{
		kdNetwork.Attack(coordX);
	}

	private void OnOpen()
	{
		kdNetwork.Login(myName);
	}

	private void BeAttacked(float coordX, string byUser)
	{
		Debug.Log("beattacked " + coordX);
		var enemyMissile = Instantiate(missile, new Vector3(coordX, 6, 200), Quaternion.identity) as GameObject;
		enemyMissile.GetComponent<Missile>().SetDirection(Vector2.down);
		enemyMissile.GetComponent<Missile>().SetSpeed(2f);
		enemyMissile.GetComponentInChildren<TextMesh>().text = byUser;
		enemyMissile.GetComponentInChildren<TextMesh>().GetComponent<MeshRenderer>().sortingOrder = 2;

	}
}
