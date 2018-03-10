using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using UnityEngine.UI;
using DG.Tweening;
public class KeyboardInput : MonoBehaviour {

	StringBuilder stringBuilder;
	[HideInInspector]public string answer;
	bool getInputState = true;
	// Button button;
	Sequence sequence;

	// Use this for initialization
	void Start () {
		sequence = DOTween.Sequence();
		stringBuilder = new StringBuilder();
		// button = GameObject.Find("a").GetComponent<Button>();
	}
	
	public string GetStringBuilder()
	{
		return stringBuilder.ToString();
	}

	void Update () {
		
		if (getInputState)
		{
			if (Input.anyKeyDown)
			{
				// Debug.Log("input: " + Input.inputString);
				
				if (!Input.inputString.Equals(""))
				{
					var input = Input.inputString.ToLower();
					GameObject button;
					
					if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Backspace))
					{
						// Debug.Log("enter");	
					}
					else if (input.Length >= 1)
					{
						input = input.Substring(Input.inputString.Length-1, 1);
						button = GameObject.Find(input).GetComponentInChildren<BoxCollider>().gameObject;											
						button.transform.DOPunchScale(Vector3.forward * 20, 1f, 15, 1).SetEase(Ease.OutQuint);
					}
					
				}

				if (Input.GetKeyDown(KeyCode.Return))
				{
					answer = stringBuilder.ToString();
					Debug.Log("answer: " + answer);
					stringBuilder.Remove(0, stringBuilder.Length);

					var gameManager = FindObjectOfType<GameManager>();
					gameManager.CompareAnswer(answer);

					answer = "";

				}
				else if (Input.GetKeyDown(KeyCode.Backspace))
				{
					stringBuilder.Remove(stringBuilder.Length - 1, 1);
				}
				else if (Input.GetKeyDown(KeyCode.Space))
				{
					
				}
				else
				{
					stringBuilder.Append(Input.inputString);		
				}
			}
		}

	}
}
