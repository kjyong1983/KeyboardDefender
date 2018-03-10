using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	
	int life = 100;
	int mana = 100;
	int score = 0;
	bool isCorrect = false;
	KeyboardInput keyboardInput;
	Questions questions;
	// Use this for initialization
	void Start () {
		keyboardInput = FindObjectOfType<KeyboardInput>();
		questions = FindObjectOfType<Questions>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void CompareAnswer(string answer)
	{
		isCorrect = questions.IsSame(answer);
		if (isCorrect)
		{
			score += 100;
			Debug.Log("correct!");
		}
		else
		{
			Debug.Log("nah");
		}
	}
}
