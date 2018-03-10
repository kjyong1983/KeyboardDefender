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
	// Use this for initialization
	void Start () {
		keyboardInput = FindObjectOfType<KeyboardInput>();
		questions = FindObjectOfType<Questions>();
		player = GameObject.FindWithTag("Player");
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
}
