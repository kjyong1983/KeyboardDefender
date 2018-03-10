using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionDisplay : MonoBehaviour {

	public List<Text> questionDisplayText;

	void Awake () {
		questionDisplayText = new List<Text>();
		for (int i = 0; i < 9; i++)
		{
			questionDisplayText.Add(GameObject.Find("Text" + i.ToString()).GetComponent<Text>());
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
