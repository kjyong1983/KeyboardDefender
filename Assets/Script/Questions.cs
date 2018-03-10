using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using System.Linq;
public class Questions : MonoBehaviour {

	QuestionParser vocaList;
	Queue<int> randomIntList;
	QuestionDisplay display;
	// SortedDictionary<string, string> questions;
	const string emptyText = "empty";

	const int CAPACITY = 200;
	string question = "";
	int currentQuestionNumber = 0;

	void Start()
	{
		vocaList = FindObjectOfType<QuestionParser>();
		randomIntList = new Queue<int>();

		for (int i = 0; i < CAPACITY; i++)
		{
			randomIntList.Enqueue(Random.Range(0, vocaList.voca.Count));			
		}
		display = FindObjectOfType<QuestionDisplay>();

		StartCoroutine(AssignQuestions());
	}

	IEnumerator AssignQuestions()
	{
		Debug.Log("InitQuestions " + display.questionDisplayText.Count);
		for (int i = 0; i < display.questionDisplayText.Count; i++)
		{
			if (display.questionDisplayText[i].text.Equals(emptyText))
			{
				currentQuestionNumber = randomIntList.Dequeue();
				display.questionDisplayText[i].text = vocaList.voca[currentQuestionNumber.ToString()][1];
				// Debug.Log("question: " + question);			
			}
			
		}

		yield break;
	}

	public bool CheckAnswers(string str)
	{
		bool returnValue = false;
		for (int i = 0; i < display.questionDisplayText.Count; i++)
		{
			if (str.Equals(display.questionDisplayText[i].text))
			{
				display.questionDisplayText[i].text = emptyText;
				StartCoroutine(AssignQuestions());
				return true;
			}
			// else
			// {
			// 	returnValue = false;
			// }
			
		}

		return returnValue;
	}

	public bool IsSame(string str)
	{
		// if (str.Equals(question))
		// {
		// 	question = "";
		// 	return true;
		// }
		// else
		// {
		// 	return false;
		// }
		return false;
	}
}
