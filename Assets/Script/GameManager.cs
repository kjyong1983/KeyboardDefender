using SocketIO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	
	public int life = 100;
	int mana = 100;
	int score = 0;
	bool isCorrect = false;
	KeyboardInput keyboardInput;
	Questions questions;

	GameObject player;

	KDNetwork kdNetwork;

	// Use this for initialization
	void Start () {
		keyboardInput = FindObjectOfType<KeyboardInput>();
		questions = FindObjectOfType<Questions>();
		player = GameObject.FindWithTag("Player");

		kdNetwork = new KDNetwork(GameObject.Find("SocketIO").GetComponent<SocketIOComponent>());
		kdNetwork.OnOpen += OnOpen;
		kdNetwork.BeAttacked += BeAttacked;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void CompareAnswer(string answer)
	{
		// isCorrect = questions.IsSame(answer);
		isCorrect = FindObjectOfType<Questions>().CheckAnswers(answer);
		if (isCorrect)
		{
			score += 100;
			if (player.GetComponent<PlayerController>().missileCapacity <= 5)
			{
				player.GetComponent<PlayerController>().missileCapacity += 1;				
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

	}

	private void BeAttacked(float coordX, string byUser)
	{
		// TODO missile down
	}
}
